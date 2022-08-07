#include "Planner.h"

void PlannerClass::init(vector<Segment>* SegmentQueue)
{
	StepsPerDeg[0] = (float)THETA1_STEPS_PER_2PI / 360.0;
	StepsPerDeg[1] = (float)THETA2_STEPS_PER_2PI / 360.0;
	StepsPerDeg[2] = (float)THETA3_STEPS_PER_2PI / 360.0;

	this->SegmentQueue = SegmentQueue;

	LastError[0] = 0;
	LastError[1] = 0;
	LastError[2] = 0;
}

void PlannerClass::AddHomeSegment()
{
	float timeForOneStep = 1 / (Data.MovingHomeSpeed * StepsPerDeg[0]);
	HomingIntCycle = timeForOneStep * TIME_TO_US;

	Segment segbuffer;

	segbuffer.NumberINT = 2 * STEP_NULL;

	for (uint8_t i = 0; i < 3; i++)
	{
		segbuffer.StepperArray[i].StepsToJump = STEP_NULL;
		segbuffer.StepperArray[i].Direction = DECREASE;
	}
	SegmentQueue->push_back(segbuffer);

	LastError[0] = 0;
	LastError[1] = 0;
	LastError[2] = 0;
}

void PlannerClass::AddSegment(float* offset, float timeMove)
{
	Segment segbuffer;
	segbuffer.NumberINT = roundf(timeMove * TIME_TO_NUMINT);

	for (uint8_t i = 0; i < 3; i++)
	{
		segbuffer.StepperArray[i] = ChangeToStep(offset, i);
		if (segbuffer.NumberINT < segbuffer.StepperArray[i].StepsToJump)
		{
			segbuffer.NumberINT = segbuffer.StepperArray[i].StepsToJump;
		}
	}
	SegmentQueue->push_back(segbuffer);
}

Step PlannerClass::ChangeToStep(float* offset, uint8_t index)
{
	Step stepBuffer;

	float realStepsToJump = offset[index] * StepsPerDeg[index];

	realStepsToJump -= LastError[index];

	if (offset[index] >= 0)
	{
		stepBuffer.Direction = INCREASE;
		realStepsToJump = realStepsToJump;
	}
	else
	{
		stepBuffer.Direction = DECREASE;
		realStepsToJump = -realStepsToJump;
	}

	stepBuffer.StepsToJump = roundf(realStepsToJump);

	LastError[index] = stepBuffer.StepsToJump - realStepsToJump;
	
	if (offset[index] < 0)
	{
		LastError[index] = -LastError[index];
	}

	return stepBuffer;
}

void PlannerClass::SetVelocity(float velocity)
{
	if (velocity > DEFAULT_MAX_VELOCITY)
	{
		Data.Velocity = DEFAULT_MAX_VELOCITY;
	}
	else
	{
		Data.Velocity = velocity;
	}
}

void PlannerClass::SetAcceleration(float acceleration)
{
	if (acceleration > DEFAULT_MAX_ACCELERATION)
	{
		Data.Acceleration = DEFAULT_MAX_ACCELERATION;
	}
	else
	{
		Data.Acceleration = acceleration;
	}
}

void PlannerClass::SetHomeSpeed(float velocity)
{
	Data.MovingHomeSpeed = velocity;
	float timeForOneStep = 1 / (Data.MovingHomeSpeed * StepsPerDeg[0]);
	HomingIntCycle = timeForOneStep * TIME_TO_US;
}

void PlannerClass::SetBeginEndVelocity(float velocity)
{
	Data.BeginEndVelocity = velocity;
}

PlannerClass Planner;

//code dieu chinh ve van toc
void Velocity_Planner_Class::plan(float _distance2Point)
{
	V_desired = Data.Velocity;
	road_length = _distance2Point;
	if (!Data.isLink)
	{
		if (last_link)
		{
			V_begin = V_end;
			V_end 	= Data.BeginEndVelocity;
		}
		else
		{
			V_begin = Data.BeginEndVelocity;
			V_end 	= Data.BeginEndVelocity;
		}
	}
	else //code linked here;
	{
		V_begin = V_end;
		V_end 	= V_desired;
	}
	last_link = Data.isLink;

	Ta = (V_desired - V_begin) / Data.Acceleration;
	if (Ta > 0)
	{
		accel_a = Data.Acceleration;
	}
	else if (Ta == 0)
	{
		accel_a = 0;
	}
	else if (Ta < 0)
	{
		accel_a = - Data.Acceleration;
		Ta = - Ta;
	}

	Tb = (V_end - V_desired) / Data.Acceleration;
	if (Tb > 0)
	{
		accel_b = Data.Acceleration;
	}
	else if (Tb == 0)
	{
		accel_b = 0;
	}
	else if (Tb < 0)
	{
		accel_b = - Data.Acceleration;
		Tb = - Tb;
	}

	S1 = (V_begin + V_desired) * Ta / 2;
	S2 = (V_end + V_desired) * Tb / 2;

	if (road_length > (S1 + S2))
	{
		S3 = road_length;
		S2 = S3 - S2;
		case_delta = false; 
	}
	else if (road_length <= (S1 + S2))
	{
		V_desired = V_begin + accel_a * ((sqrt(V_begin * V_begin + accel_a * road_length) - V_begin) / accel_a);
		case_delta = true; 
	}
}

float Velocity_Planner_Class::V_atPoint_Cal(float _length_at_point)
{
	float t ;
	point_length = _length_at_point;

	if (!case_delta)
	{
		if (point_length < S1)
		{
			t = sqrt(2 * point_length / accel_a);
			V_atPoint = V_begin + t * accel_a;
		}
		else if ((S1 < point_length)&&(point_length <= S2))
		{
			V_atPoint = V_desired;
		}
		else if ((S2 < point_length)&&(point_length <= S3))
		{
			t = (sqrt(V_desired * V_desired - 2 * accel_b * (S2 - point_length)) - V_desired) / accel_b;
			V_atPoint = V_desired + t * accel_b;
		}
	}
	else
	{
		if (point_length < road_length/2)
		{
			t = sqrt(2 * point_length / accel_a);
			V_atPoint = V_begin + t * accel_a;
		}
		else if (point_length >= road_length/2)
		{
			t = (sqrt(V_desired * V_desired - 2 * accel_b * (road_length/2 - point_length)) - V_desired) / accel_b;
			V_atPoint = V_desired + t * accel_b;
		}
	}
	return V_atPoint;
}

float Velocity_Planner_Class::V_Moving_Time_Cal(float _length, float _lastV, float _currentV)
{
	return (2 * _length / (_lastV + _currentV));
}

Velocity_Planner_Class V_planner;
