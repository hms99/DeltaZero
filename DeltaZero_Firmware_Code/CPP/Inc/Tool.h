#ifndef _TOOL_h
#define _TOOL_h

#include <math.h>
#include "Constants.h"
#include "stm32f1xx_hal.h"

class ToolClass
{
 public:
	void init();
	Point ConvertToPoint(float xPos, float yPos, float zPos);
	bool CheckingDesiredPoint(Point point);
	bool CheckingDesiredAngle(Angle angle);
	Point GetPointInLine(Point currentP, Point desiredP, float t);
	Point GetPointInCircle(float ox, float oy, float desiredP, float angle);
	bool CheckFuplicatione(Point point1, Point point2);
	float CalDistance2Point(Point point1, Point point2);
	bool IsWait;
	bool Wait();
	void SetTimeDelay(float timeDelay);

private:
	uint32_t TimeDelay;
	uint32_t LastTime;
};

extern ToolClass Tool;

#endif

