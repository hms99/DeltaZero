/*
 * CppMain.h
 *
 *  Created on: May 30, 2022
 *      Author: MINE
 */

#ifndef INC_CPPMAIN_H_
#define INC_CPPMAIN_H_


//include cac header can cho delltaZero

#include "serialObject.h"
#include "singleServo.h"

#include "config.h"
#include "Constants.h"
#include <vector>
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

#endif /* INC_CPPMAIN_H_ */
