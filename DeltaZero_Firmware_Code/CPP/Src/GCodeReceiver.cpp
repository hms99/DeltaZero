#include "GCodeReceiver.h"

void GCodeReceiverClass::Init()
{
	reset_receiveString();
}

void GCodeReceiverClass::Execute()
{
	if (Serial.available())
	{
		Serial.read_return(recei_String);
		strcpy(receiveString.s, recei_String);
		Serial.reset_read_string();
	}

	if (receiveString.s[0] == 'M' || receiveString.s[0] == 'G')
	{
		GCodeQueue.push_back(receiveString);
		reset_receiveString();
		return;
	}

	if (strcmp(receiveString.s, ":Position") == 0)
		{
			respondCurrentPosition();
		}
	else if (strcmp(receiveString.s, ":IsDelta") == 0)
		{
			Serial.print_char(":Yes");
		}
		
	reset_receiveString();
}

void GCodeReceiverClass::reset_receiveString() 
{
	for (uint8_t i=0; i < strlen(receiveString.s); i++)
	{
		receiveString.s[i] = 0;
	}
}

void GCodeReceiverClass::respondCurrentPosition()
{
	Serial.respond_three_element(":Position", Data.CurrentPoint.X, Data.CurrentPoint.Y, Data.CurrentPoint.Z);
}


