#include "Constants.h"

void Constants::init()
{
	RD_F = (float)DEFAULT_RD_F;
	RD_E = (float)DEFAULT_RD_E;
	RD_RF = (float)DEFAULT_RD_RF;
	RD_RE = (float)DEFAULT_RD_RE;

	RD_W = (float)DEFAULT_RD_W;

	MOVING_AREA_X = (float)DEFAULT_MOVING_AREA_X;
	MOVING_AREA_Y = (float)DEFAULT_MOVING_AREA_Y;
	MOVING_AREA_Z = (float)DEFAULT_MOVING_AREA_Z;

	MOVING_AREA_LARGEST_DIAMETER = (float)DEFAULT_MOVING_AREA_LARGEST_DIAMETER;

	Velocity = (float)DEFAULT_VELOCITY;
	Acceleration = (float)DEFAULT_ACCELERATION;
	
	MovingHomeSpeed = (float)DEFAULT_MOVING_HOME_SPEED;

	BeginEndVelocity = (float)DEFAULT_BEGIN_VELOCITY;

	EntryVelocity = (float)DEFAULT_ENTRY_VELOCITY;
	ExitVelocity = (float)DEFAULT_EXIT_VELOCITY;

	IsMoveWithTheAbsoluteCoordinates = true;
	IsExecutedGcode = false;

	WPosition = 0;
	Vacuum = 0;
	speed_loader = 0;
	dir_loader = 1;

	MMPerLinearSegment = (float)MM_PER_LINEAR_SEGMENT;

	MMPerArcSegment = (float)MM_PER_ARC_SEGMENT;
}

void Constants::ResetData()
{
	init();
}

Constants Data;

