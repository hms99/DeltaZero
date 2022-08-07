#ifndef _PLANNER_h
#define _PLANNER_h

#include <vector>
#include <stdint.h>
#include <math.h>
#include "config.h"
#include "enum.h"
#include "Constants.h"
#include "serialObject.h"

#define US_TO_NUMINT (1.0 / INTERRUPT_CYCLE_MIN)
#define TIME_TO_US 1000000.0
#define TIME_TO_NUMINT (1000000.0 / INTERRUPT_CYCLE_MIN)
#define STEP_NULL 65530

using namespace std;

typedef struct
{
	uint16_t StepsToJump;
	bool Direction;
} Step;

class Segment
{
public:
	Step StepperArray[3];
	uint32_t NumberINT;
};

class PlannerClass
{
 public:
	void init(vector<Segment>* SegmentQueue);
	void AddHomeSegment();
	void AddSegment(float* offset, float lengthOfRoad);

	vector<Segment>* SegmentQueue;

	void SetVelocity(float velocity);
	void SetMaxVelocity(float velocity);
	void SetAcceleration(float acceleration);
	void SetHomeSpeed(float velocity);
	void SetBeginEndVelocity(float velocity);

	float LastError[3];
	float a;
	float HomingIntCycle;
	bool one_seg_flag;

 private:
	Step ChangeToStep(float* offset, uint8_t index);
	float StepsPerDeg[3];
};
extern PlannerClass Planner;

class Velocity_Planner_Class
{
	public:
		float T;
		bool last_link;
		void plan(float _distance2Point);
		float V_atPoint_Cal(float _length_at_point);
		float V_Moving_Time_Cal(float _length, float _lastV, float _currentV);
		float lastV = 0;
		
	private:
		float S1;
		float S2;
		float S3;

		float Ta;
		float Tb;

		float accel_a;
		float accel_b;
		bool case_delta;

		float road_length;
		float point_length;
		float V_desired;
		float V_atPoint;
		float V_begin;
		float V_end;
};
extern Velocity_Planner_Class V_planner;
#endif
