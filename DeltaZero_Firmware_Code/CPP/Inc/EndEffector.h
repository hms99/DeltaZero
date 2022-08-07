#ifndef _ENDEFFECTOR_h
#define _ENDEFFECTOR_h

#include "config.h"
#include "Constants.h"
#include "enum.h"
#include "pin.h"
#include "singleServo.h"
#include "serialObject.h"

class EndEffectorClass
{
 public:
	void init();
	void Reset();
	void Servo(int _value);
	void Vacuum(uint8_t _value);
};

extern EndEffectorClass EndEffector;

#endif

