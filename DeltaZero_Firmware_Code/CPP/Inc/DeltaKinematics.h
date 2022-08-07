#ifndef _DELTAKINEMATICS_h
#define _DELTAKINEMATICS_h

#include <math.h>
#include "Constants.h"
#ifndef pi
#define pi 3.1415
#endif
#define DEG_TO_RAD (pi/180)//0.01745
#define RAD_TO_DEG (180/pi)//57.29578

using namespace std;

//trigonometric constants
const double tan30 = 1 / sqrt(3);
const double tan30x05 = 0.5 / sqrt(3);
const double tan60 = sqrt(3);
const double sin30 = 0.5;
const double cos30 = sqrt(3) / 2;
const double cos120 = -0.5;
const double sin120 = sqrt(3) / 2;

class DeltaKinematicsClass
{
 public:
	void init();
	bool ForwardKinematicsCalculations(Angle angleposition, Point &point);
	bool InverseKinematicsCalculations(Point point, Angle &angleposition);

private:
	bool AngleThetaCalculations(float x0, float y0, float z0, float &theta);
	float _y0_;
	float _y1_;
	float RD_RF_Pow2;
	float RD_RE_Pow2;
};

extern DeltaKinematicsClass DeltaKinematics;

#endif

