#ifndef _CONSTANTS_h
#define _CONSTANTS_h

#include "config.h"
#include "enum.h"
#include "Geometry.h"
#include <stdint.h>

typedef struct
{
	float X;
	float Y;
	float Z;
}Point;

typedef struct
{
	float Theta1;
	float Theta2;
	float Theta3;
}Angle;

class Constants
{
public:
	void	init();
	void 	ResetData();

	float	RD_F;
	float	RD_E;
	float	RD_RF;
	float	RD_RE;

	float	RD_W;

	float	MOVING_AREA_X;
	float	MOVING_AREA_Y;
	float	MOVING_AREA_Z;

	float	MOVING_AREA_LARGEST_DIAMETER;

	float	Velocity;			//mm/s
	float	Acceleration;		//mm/s^2

	float MovingHomeSpeed;

	float BeginEndVelocity;

	float EntryVelocity;
	float ExitVelocity;
	bool IsMoveWithTheAbsoluteCoordinates;

	bool IsExecutedGcode;

	float MMPerLinearSegment;
	float MMPerArcSegment;

	Point CurrentPoint;
	Point DesiredPoint;
	Point HomePosition;

	Angle CurrentAngle;

	float ZOffset;

	int WPosition;

	uint8_t Vacuum;

	float speed_loader;
	uint8_t dir_loader;

	bool isLink = false;
};

extern Constants Data;

#endif

