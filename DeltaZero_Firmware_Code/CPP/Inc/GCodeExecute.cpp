#include "GCodeExecute.h"

void GCodeExecuteClass::Init()
{
	ResetValue();
	IsRunning = false;
}

void GCodeExecuteClass::Run()
{
	WhenFinishMove();
	if (GCodeQueue.size() == 0 || IsRunning == true)
	{
		return;
	}

	String GcodeInProcessing = GCodeQueue.operator[](0);
	vector<KeyValue> keyValues = getKeyValues(GcodeInProcessing);

	for (uint8_t i = 1; i < keyValues.size(); i++)
	{
		switch (keyValues[i].Key)
		{
		case 'X':
			X = keyValues[i].Value;
			break;
		case 'Y':
			Y = keyValues[i].Value;
			break;
		case 'Z':
			Z = keyValues[i].Value;
			break;
		case 'E':
			E = keyValues[i].Value;
			break;
		case 'S':
			S = keyValues[i].Value;
			break;
		case 'A':
			A = keyValues[i].Value;
			break;
		case 'I':
			I = keyValues[i].Value;
			break;
		case 'J':
			J = keyValues[i].Value;
			break;
		case 'F':
			F = keyValues[i].Value;
			break;
		case 'P':
			P = keyValues[i].Value;
			break;
		case 'R':
			R = keyValues[i].Value;
			break;
		case 'Q':
			Q = keyValues[i].Value;
			break;
		case 'W':
			W = keyValues[i].Value;
			break;
		case 'V':
			V = keyValues[i].Value;
			break;
		case 'K':
			K = keyValues[i].Value;
			break;
		default:
			break;
		}
	}

	checkAndRunFunction(keyValues[0]);
	GCodeQueue.erase(GCodeQueue.begin());
	IsRunning = true;
}

void GCodeExecuteClass::WhenFinishMove()
{
	if (Stepper.GetStateMotor() == true)
	{
		if (IsRunning == true)
		{
			if (Data.IsExecutedGcode == true)
			{
				//Serial.print_char(":Done\n");	
				//GcodeReceiver.respondCurrentPosition();
			}
			else
			{
				if (Tool.IsWait == true)
				{
					if (!Tool.Wait())
					{
						return;
					}
					//Serial.print_char(":Wait_Cmplt\n");
					Tool.IsWait = false;
				}
				else
				{
					//Serial.print_char(":Breaking\n");
				}				
			}
			IsRunning = false;
			Data.IsExecutedGcode = false;
		}
	}
}

void GCodeExecuteClass::checkAndRunFunction(KeyValue keyValue)
{
	switch (keyValue.Key)
	{
	case 'G':
		switch ((int)keyValue.Value)
		{
		case 0:
			if (F != NULL_NUMBER) Planner.SetVelocity(F);
			if (X == NULL_NUMBER) X = Data.CurrentPoint.X;
			if (Y == NULL_NUMBER) Y = Data.CurrentPoint.Y;
			if (Z == NULL_NUMBER) Z = Data.CurrentPoint.Z;
			if (W == NULL_NUMBER) W = Data.WPosition;
			if (V == NULL_NUMBER) V = Data.Vacuum;
			Motion.G1_0(X, Y, Z, W, V);
			break;
		case 1:
			if (F != NULL_NUMBER) Planner.SetVelocity(F);
			if (X == NULL_NUMBER) X = Data.CurrentPoint.X;
			if (Y == NULL_NUMBER) Y = Data.CurrentPoint.Y;
			if (Z == NULL_NUMBER) Z = Data.CurrentPoint.Z;
			if (W == NULL_NUMBER) W = Data.WPosition;
			if (V == NULL_NUMBER) V = Data.Vacuum;
			Motion.G1_0(X, Y, Z, W, V);
			break;
		case 2:
			if (I == NULL_NUMBER) break;
			if (J == NULL_NUMBER) break;
			if (F != NULL_NUMBER) Planner.SetVelocity(F);
			if (X == NULL_NUMBER) X = Data.CurrentPoint.X;
			if (Y == NULL_NUMBER) Y = Data.CurrentPoint.Y;
			if (W == NULL_NUMBER) W = Data.WPosition;
			Motion.G2_3(I, J, X, Y, W, false);
			break;
		case 3:
			if (I == NULL_NUMBER) break;
			if (J == NULL_NUMBER) break;
			if (F != NULL_NUMBER) Planner.SetVelocity(F);
			if (X == NULL_NUMBER) X = Data.CurrentPoint.X;
			if (Y == NULL_NUMBER) Y = Data.CurrentPoint.Y;
			if (W == NULL_NUMBER) W = Data.WPosition;
			Motion.G2_3(I, J, X, Y, W, true);
			break;
		case 4:
			if (P == NULL_NUMBER) break;
			Motion.G4(P);
			break;
		case 6:
			if (F != NULL_NUMBER) Planner.SetVelocity(F);
			if (X == NULL_NUMBER) X = Data.CurrentPoint.X;
			if (Y == NULL_NUMBER) Y = Data.CurrentPoint.Y;
			if (Z == NULL_NUMBER) Z = Data.CurrentPoint.Z;
			if (W == NULL_NUMBER) W = Data.WPosition;
			Motion.G6(X, Y, Z, W);
			break;
		case 28:
			Motion.G28();
			break;
		case 90:
			Control.G90();
			break;
		case 91:
			Control.G91();
			break;
		default:
			break;
		}
		break;
	case 'M':
		switch ((int)keyValue.Value)
		{
		case 84:
			Control.M84();
			break;
		case 203:
			if (S == NULL_NUMBER) break;
			Control.M203(S);
			break;
		case 204:
			if (A == NULL_NUMBER) break;
			Control.M204(A);
			break;
		case 206:
			if (Z == NULL_NUMBER) break;
			Control.M206(Z);
			break;
		case 207:
			if (P == NULL_NUMBER) break;
			Control.M207(P);
			break;
		case 361:
			if (P == NULL_NUMBER) break;
			Control.M361(P);
			break;
		case 362:
			if (P == NULL_NUMBER) break;
			Control.M362(P);
			break;
		case 370:
			if (K == NULL_NUMBER) K = Data.speed_loader;
			Control.M370(K);
			break;
		case 11:
			Control.M11();
			break;
		default:
			break;
		}
		break;
	default:
		break;
	}
	ResetValue();
}

vector<KeyValue> GCodeExecuteClass::getKeyValues(String code)
{
	vector<KeyValue> keyValues;
	char splitWord[20];
	memset(splitWord,'\0',20);
	strcat(code.s," ");
	for (uint16_t i = 0; i < strlen(code.s); i++)
	{
		if (code.s[i] == ' ')
		{
			if (strlen(splitWord)== 0)
				continue;
			KeyValue keyValue;
			keyValue.Key = splitWord[0];
			splitWord[0] = '0';

			int dau;
			if (splitWord[1] == '-')
			{
				dau = -1;
				splitWord[1] = '0';
			}
			else
			{
				dau = 1;
			}
			keyValue.Value = dau * atof(splitWord);
			keyValues.push_back(keyValue);
			memset(splitWord,'\0',20);
			continue;
		}
		splitWord[strlen(splitWord)] = code.s[i];
		splitWord[strlen(splitWord)+1] = '\0';
	}
	return keyValues;
}

void GCodeExecuteClass::ResetValue()
{
	X = NULL_NUMBER;
	Y = NULL_NUMBER;
	Z = NULL_NUMBER;
	E = NULL_NUMBER;
	S = NULL_NUMBER;
	A = NULL_NUMBER;
	I = NULL_NUMBER;
	J = NULL_NUMBER;
	F = NULL_NUMBER;
	P = NULL_NUMBER;
	R = NULL_NUMBER;
	Q = NULL_NUMBER;
	W = NULL_NUMBER;
	V = NULL_NUMBER;
	K = NULL_NUMBER;
}
