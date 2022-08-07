#ifndef _GCODEEXECUTE_h
#define _GCODEEXECUTE_h

#include <vector>
#include <string.h>
#include <stdlib.h>
#include "enum.h"
#include "Motion.h"
#include "GCodeReceiver.h"
#include "serialObject.h"
#include "Control.h"
#define NULL_NUMBER 98765

using namespace std;

class KeyValue
{
public:
	char Key;
	float Value;
};
extern vector<String> GCodeQueue;
extern GCodeReceiverClass GcodeReceiver;
class GCodeExecuteClass
{
public:
	void Init();
	void Run();
	void WhenFinishMove();
	bool IsRunning;
	float X, Y, Z, E, S, A, I, J, F, P, R, Q, W, V, K;
private:
	vector<KeyValue> getKeyValues(String code);
	void checkAndRunFunction(KeyValue keyValue);
	void ResetValue();
};

#endif

