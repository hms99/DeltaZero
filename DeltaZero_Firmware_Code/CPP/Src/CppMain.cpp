/*
 * CppMain.cpp
 *
 *  Created on: May 30, 2022
 *      Author: MINE
 */
#include "main.h"

#include <vector>
#include "serialObject.h"
#include "singleServo.h"
#include "config.h"
#include "Constants.h"
#include "GCodeReceiver.h"
#include "GCodeExecute.h"
#include "Planner.h"
#include "Motion.h"
#include "Tool.h"
#include "EndEffector.h"

using namespace std;

GCodeReceiverClass GcodeReceiver;
GCodeExecuteClass GcodeExecute;
vector<String> GCodeQueue;
vector<Segment> SegmentQueue;

void CppMain()
{
	//setup
	Serial.Init();
	Data.init();
	DeltaKinematics.init();
	EndEffector.init();
	Planner.init(&SegmentQueue);
	Stepper.init(&SegmentQueue);
	Motion.init();
	GcodeReceiver.Init();
	GcodeExecute.Init();
	Serial.print_char("Init Success! \n");
	
	servo.Init();
	Motion.G28();
	Motion.SetHomePosition();
	
	while(1)
	{
		GcodeReceiver.Execute();
		GcodeExecute.Run();
	}
}




