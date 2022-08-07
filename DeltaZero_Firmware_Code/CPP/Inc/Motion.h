#ifndef _MOTION_h
#define _MOTION_h

#include "Constants.h"
#include "Tool.h"
#include "DeltaKinematics.h"
#include "Planner.h"
#include "Stepper.h"
#include "EndEffector.h"

class MotionClass
{
public:
	void init();
	void G1_0(float xPos, float yPos, float zPos, float wPos, uint8_t Vacuum);
	void G2_3(float i, float j, float xPos, float yPos, float wPos, bool clockwise);
	void G4(float p);
	void G6(float angle1, float angle2, float angle3, float wPos);
	void G28();
	void SetHomePosition();

private:
	uint16_t NumberSegment;
	bool LinearInterpolation();
	bool CircleInterpolation(float i, float j, bool clockwise);
	void UploadSegment(Angle angle1, Angle angle2, float distance);
	bool last_is_homing;
};

extern MotionClass Motion;

#endif

