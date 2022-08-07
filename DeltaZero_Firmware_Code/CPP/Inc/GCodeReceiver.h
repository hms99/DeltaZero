#ifndef _GCODERECEIVER_h
#define _GCODERECEIVER_h

#include <vector>
#include <string.h>
#include "Constants.h"
#include "stm32f1xx_hal.h"
#include "serialObject.h"
typedef struct {
	char s[40];
} String;
using namespace std;
extern vector<String> GCodeQueue;
class GCodeReceiverClass
{
public:
	void Init();
	void Execute();
	void reset_receiveString();
	void respondCurrentPosition();
private:
	String receiveString;
	char recei_String[30];
};

#endif

