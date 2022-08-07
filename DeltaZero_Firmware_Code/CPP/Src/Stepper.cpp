#include "Stepper.h"

void StepperClass::init(vector<Segment>* SegmentQueue)
{
	this->SegmentQueue = SegmentQueue;
	__HAL_TIM_SET_AUTORELOAD(&htim3, CCP_time);
	CreateMotor();

	IsRunningHome = false;
	IsStoppedMoving = true;
}

void StepperClass::CreateMotor()
{
	ThetaStepMotor[0].Name = THETA_1;

	ThetaStepMotor[1].Name = THETA_2;

	ThetaStepMotor[2].Name = THETA_3;
}

void StepperClass::ClearMotorArray()
{
	for (int8_t i = 0; i < 3; i++)
	{
		ThetaStepMotor[i].InterruptNumberNextStep = 0;
	}
}

bool StepperClass::GetStateMotor()
{
	return IsStoppedMoving;
}

void StepperClass::UpdateMoveSegment()
{
	if (SegmentQueue->size() == 0)
	{
		IsStoppedMoving = true;
		NumberTnterrupt = 0;
		Timer = 0;
		TurnOffTimer_(2);
		return;
	}

	CurrentMoveSegment = SegmentQueue->operator[](0);
	SegmentQueue->erase(SegmentQueue->begin());

	for (uint8_t i = 0; i < 3; i++)
	{
		setMotorDirection(ThetaStepMotor[i].Name, CurrentMoveSegment.StepperArray[i].Direction);
		ThetaStepMotor[i].InterruptNumberNextStep = 0;
		if (CurrentMoveSegment.StepperArray[i].StepsToJump == 0)
		{
			ThetaStepMotor[i].NumberInterrupt2Step = STEP_NULL * 10;
		}
		else
		{
			ThetaStepMotor[i].NumberInterrupt2Step = (float)CurrentMoveSegment.NumberINT / CurrentMoveSegment.StepperArray[i].StepsToJump;
		}
	}
	
	NumberTnterrupt = 0;
}

void StepperClass::Running()
{	
	if (SegmentQueue->size() == 0)
	{
		return;
	}
	CurrentMoveSegment = SegmentQueue->operator[](0);
	SegmentQueue->erase(SegmentQueue->begin());

	for (uint8_t i = 0; i < 3; i++)
	{
		setMotorDirection(ThetaStepMotor[i].Name, CurrentMoveSegment.StepperArray[i].Direction);
		ThetaStepMotor[i].InterruptNumberNextStep = 0;
		if (CurrentMoveSegment.StepperArray[i].StepsToJump == 0)
		{
			ThetaStepMotor[i].NumberInterrupt2Step = STEP_NULL;
		}
		else
		{
			ThetaStepMotor[i].NumberInterrupt2Step = (float)CurrentMoveSegment.NumberINT / CurrentMoveSegment.StepperArray[i].StepsToJump;
		}
	}

	set_TC(INTERRUPT_CYCLE_MIN);

	IsStoppedMoving = false;
	TurnOnTimer_(2);
}

void StepperClass::Isr_Execute_Velocity()
{
	if (IsRunningHome)
	{
		for (uint8_t i = 1; i <= 3; i++)
		{
			if (check_end_stop_(i))
			{
				CurrentMoveSegment.StepperArray[i - 1].StepsToJump = 0;
			}
		}
		if(check_end_stop_(4))
		{
			CurrentMoveSegment.StepperArray[0].StepsToJump = 0;
			CurrentMoveSegment.StepperArray[1].StepsToJump = 0;
			CurrentMoveSegment.StepperArray[2].StepsToJump = 0;
			IsRunningHome = false;
			IsStoppedMoving = true;
			TurnOffTimer_(2);
			TurnOffTimer_(3);
			return;
		}
	}

	NumberTnterrupt++;

	if (IsRunningHome)
	{
		CurrentCycle = Planner.HomingIntCycle;
	}
	else
	{
		CurrentCycle = INTERRUPT_CYCLE_MIN;
	}
	set_TC(CurrentCycle);

	for (uint8_t i = 0; i < 3; i++)
	{
		if (ThetaStepMotor[i].InterruptNumberNextStep >= NumberTnterrupt)
		{
			continue;
		}

		ThetaStepMotor[i].InterruptNumberNextStep += ThetaStepMotor[i].NumberInterrupt2Step;
		if (CurrentMoveSegment.StepperArray[i].StepsToJump != 0)
		{
			CurrentMoveSegment.StepperArray[i].StepsToJump--;
			writePulsePin(ThetaStepMotor[i].Name, 0);
		}
	}

	TurnOnTimer_(3);
	if (Stepper.CurrentMoveSegment.StepperArray[0].StepsToJump == 0 
	&& Stepper.CurrentMoveSegment.StepperArray[1].StepsToJump == 0 
	&& Stepper.CurrentMoveSegment.StepperArray[2].StepsToJump == 0)
	{
		Stepper.UpdateMoveSegment();
	}
}

bool StepperClass::set_TC(float _curerent_TC)
{
	if (_curerent_TC<1300000)
		{
			 prescaler = 90;
		}
	else if (_curerent_TC>=1300000)
		{
			 prescaler = 90*8;
		}
	if (prescaler_last != prescaler)
		{
			prescaler_last = prescaler;
			__HAL_TIM_SET_PRESCALER(&htim2, prescaler);
			TIM2->EGR = TIM_EGR_UG;
			return false;
		}
	prescaler_last = prescaler;

	uint16_t ARR_value = (uint16_t) roundf(_curerent_TC * F_CPU / (1000000.0 * prescaler)) - 1;
	__HAL_TIM_SET_AUTORELOAD(&htim2, ARR_value);
	return true;
}

//turning pulse pin high
void StepperClass::Isr_Turn_Pulse_Pin()
{
	for (uint8_t i = 0; i < 3; i++)
	{
		writePulsePin(ThetaStepMotor[i].Name, 1);
	}
	TurnOffTimer_(3);
}

bool StepperClass::check_end_stop_(uint8_t i)
{
	bool check_value;
	 switch (i)
	 {
	 	 case 1:
	 		check_value = READ(THETA1_ENDSTOP_PIN);
	 		break;
	 	 case 2:
	 		check_value = READ(THETA2_ENDSTOP_PIN);
	 		break;
	 	 case 3:
	 		check_value = READ(THETA3_ENDSTOP_PIN);
	 		break;
	 	 case 4:
	 		check_value = READ(THETA1_ENDSTOP_PIN) 
			&& READ(THETA2_ENDSTOP_PIN) 
			&& READ(THETA3_ENDSTOP_PIN);
	 		break;
	 	default:
	 		break;
	 }
	return check_value;
}

void StepperClass::setMotorDirection(AXIS axisname, bool variation)
{
	GPIO_PinState State;
	if (variation)
	{
		State = GPIO_PIN_SET;
	}
	else 
	{
		State = GPIO_PIN_RESET;
	}
	switch (axisname)
	{
	case THETA_1:
		WRITE(THETA1_DIRECTION_PIN, State);
		break;
	case THETA_2:
		WRITE(THETA2_DIRECTION_PIN, State);
		break;
	case THETA_3:
		WRITE(THETA3_DIRECTION_PIN, State);
		break;
	default:
		break;
	}
}

void StepperClass::writePulsePin(AXIS axisname, bool ison)
{
	GPIO_PinState State;
	if (ison)
	{
		State = GPIO_PIN_SET;
	}
	else 
	{
		State = GPIO_PIN_RESET;
	}
			
	switch (axisname)
	{
	case THETA_1:
		WRITE(THETA1_PULSE_PIN, State);
		break;
	case THETA_2:
		WRITE(THETA2_PULSE_PIN, State);
		break;
	case THETA_3:
		WRITE(THETA3_PULSE_PIN, State);
		break;
	default:
		break;
	}
}

void StepperClass::DisanableStepper()
{
	WRITE(ENABLE_ALL_PIN, SET);
}

void StepperClass::EnableStepper()
{
	WRITE(ENABLE_ALL_PIN, RESET);
}

void StepperClass::TurnOnTimer_(uint8_t _i)
{
	switch (_i)
	{
	case 2:
		HAL_TIM_Base_Start_IT(&htim2);
		break;
	case 3:
		HAL_TIM_Base_Start_IT(&htim3);
		break;
	default:
		break;
	}
}

void StepperClass::TurnOffTimer_(uint8_t _i)
{
	switch (_i)
	{
	case 2:
		HAL_TIM_Base_Stop_IT(&htim2);
		break;
	case 3:
		HAL_TIM_Base_Stop_IT(&htim3);
		break;
	default:
		break;
	}
}

StepperClass Stepper;

void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
	if (htim->Instance == TIM2)
		{
			Stepper.Isr_Execute_Velocity();
		}
	else if (htim->Instance == TIM3)
		{
			Stepper.Isr_Turn_Pulse_Pin();
		}
	else if (htim->Instance == TIM4)
	{
		WRITE(PUL_LOADER_PIN, SET);
	}
}

void HAL_TIM_OC_DelayElapsedCallback(TIM_HandleTypeDef *htim)
{
	if (htim->Instance == TIM4)
		{
			WRITE(PUL_LOADER_PIN, RESET);
			HAL_GPIO_TogglePin(GPIOC, GPIO_PIN_13);
		}
}
