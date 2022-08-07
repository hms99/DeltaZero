#include "EndEffector.h"

void EndEffectorClass::init()
{

}

void EndEffectorClass::Reset()
{
	Servo(0);
	Data.WPosition = 0;
}

void EndEffectorClass::Servo(int _value)
{
	int servo_position = _value;
	servo.toPosition(servo_position);
}
void EndEffectorClass::Vacuum(uint8_t _value)
{
	bool on_off =(bool) _value;
	if (on_off)
	{
		WRITE(VACCUM_PIN, SET); 
	}
	else
	{
		WRITE(VACCUM_PIN, RESET); 
	}
}

EndEffectorClass EndEffector;

