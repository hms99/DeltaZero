#ifndef _CONTROL_h
#define _CONTROL_h

#include "Constants.h"
#include "EndEffector.h"
#include "Planner.h"
#include "Stepper.h"
#include "GCodeReceiver.h"
#include "Tool.h"

extern GCodeReceiverClass GcodeReceiver;
class ControlClass
{
 public:
	void init();
	void G90();//Absolute Positioning
	void G91();//Relative Positioning

	void M84();//Disanable Step

	void M203(float s);//Set Speed
	void M204(float a);//Set acceleration
	void M206(float zPos);//Set Offset
	void M207(float BES);//Set BeginEndVelocity

	void M361(float p);//Set mm per linear segment
	void M362(float p);//Set mm per arc segment

	void M370(float v);// set stepper_loader speed and its direction
	void M11();//:Done signal
};

extern ControlClass Control;

#endif

