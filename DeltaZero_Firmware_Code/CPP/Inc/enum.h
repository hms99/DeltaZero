#pragma once
#include "config.h"

typedef enum
{
	THETA_1 = 0,
	THETA_2,
	THETA_3,
}AXIS;

#ifdef REVERSE_DIRECTION
typedef enum
{
	DECREASE = 0,
	INCREASE
}VARIATION;
#else
typedef enum
{
	INCREASE = 0,
	DECREASE
}VARIATION;
#endif // reverse direction

typedef enum
{
	USE_VACUUM = 0,
	USE_SERVO
}END_EFFECTOR;
