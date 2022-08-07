#ifndef _STEPPER_h
#define _STEPPER_h

#include <vector>
#include "config.h"
#include "Constants.h"
#include "enum.h"
#include "pin.h"
#include "Planner.h"
#include "serialObject.h"
#include "GCodeReceiver.h"
#define CCP_time 24 //0.25 ms
#define F_CPU 9000000.0

extern TIM_HandleTypeDef htim2;
extern TIM_HandleTypeDef htim3;

using namespace std;

typedef struct
{
	float InterruptNumberNextStep;
	AXIS Name;
	float NumberInterrupt2Step;
} Motor;

class StepperClass
{
 public:
	void init(vector<Segment>* SegmentQueue);
	void CreateMotor();
	bool GetStateMotor();

	void Running();
	void Homing();

	void Isr_Execute_Velocity();
	void Isr_Turn_Pulse_Pin();

	void DisanableStepper();
	void EnableStepper();

	vector<Segment>* SegmentQueue;
	bool IsRunningHome;

 private:
	uint16_t prescaler = 90;
	uint16_t prescaler_last = 90;
	Segment CurrentMoveSegment;
	float Timer;
	uint32_t NumberTnterrupt;

	Motor ThetaStepMotor[3];

	bool IsStoppedMoving;
	float CurrentCycle;

	void UpdateMoveSegment();
	bool set_TC(float _curerent_TC);
	void ClearMotorArray();
	void setMotorDirection(AXIS axisname, bool variation);
	void writePulsePin(AXIS axisname, bool ison);

	void TurnOnTimer_(uint8_t _i);
	void TurnOffTimer_(uint8_t _i);
	
	bool check_end_stop_(uint8_t i);
};

extern StepperClass Stepper;

#endif

