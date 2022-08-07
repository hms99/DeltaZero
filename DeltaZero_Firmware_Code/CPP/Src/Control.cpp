#include "Control.h"

void ControlClass::init()
{

}

void ControlClass::G90()
{
	Data.IsMoveWithTheAbsoluteCoordinates = true;

	Data.IsExecutedGcode = true;
}

void ControlClass::G91()
{
	Data.IsMoveWithTheAbsoluteCoordinates = false;

	Data.IsExecutedGcode = true;
}

void ControlClass::M84()
{
	Stepper.DisanableStepper();

	Data.IsExecutedGcode = true;
}

void ControlClass::M203(float s)
{
	Planner.SetVelocity(s);
	Data.IsExecutedGcode = true;
}

void ControlClass::M204(float a)
{
	Planner.SetAcceleration(a);
	Data.IsExecutedGcode = true;
}

void ControlClass::M206(float zPos)
{
	if (zPos == 0)
	{
		Data.ZOffset = zPos;
		Data.IsExecutedGcode = true;
	}
	if (zPos < Data.HomePosition.Z)
	{
		Data.ZOffset = zPos;
		Data.IsExecutedGcode = true;
	}
}

void ControlClass::M207(float _BES)
{
	Planner.SetBeginEndVelocity(_BES);
	Data.IsExecutedGcode = true;
}

void ControlClass::M361(float p)
{
	Data.MMPerLinearSegment = p;
	Data.IsExecutedGcode = true;
}

void ControlClass::M362(float p)
{

	Data.MMPerArcSegment = p;
	Data.IsExecutedGcode = true;
}
void ControlClass::M370(float v)
{
	servo.velocity_Stepper(v);
	Data.IsExecutedGcode = true;
}
void ControlClass::M11()
{
	Serial.print_char(":Done");
	Data.IsExecutedGcode = true;
}

ControlClass Control;

