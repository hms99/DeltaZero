#include "Motion.h"

void MotionClass::init()
{
	Angle homeAngle;

	homeAngle.Theta1 = THETA1_HOME_POSITION;
	homeAngle.Theta2 = THETA2_HOME_POSITION;
	homeAngle.Theta3 = THETA3_HOME_POSITION;
	DeltaKinematics.ForwardKinematicsCalculations(homeAngle, Data.HomePosition);
}

void MotionClass::G1_0(float xPos, float yPos, float zPos, float wPos, uint8_t vacuum)
{
	Point pointBuffer = Tool.ConvertToPoint(xPos, yPos, zPos);

	//dieu khien EndEffector
	if (wPos != Data.WPosition)
	{
		Data.WPosition = wPos;
		EndEffector.Servo(wPos);
		Data.IsExecutedGcode = true;
	}

	if (vacuum != Data.Vacuum)
	{
		Data.Vacuum = vacuum;
		EndEffector.Vacuum(vacuum);
		Data.IsExecutedGcode = true;
	}

	if (Tool.CheckingDesiredPoint(pointBuffer) == false) return;

	if (LinearInterpolation() == false) return;

	Data.IsExecutedGcode = true;
	Stepper.Running();
	NumberSegment = 0;
}

void MotionClass::G2_3(float i, float j, float xPos, float yPos, float wPos, bool _clockwise)
{
	Point pointBuffer = Tool.ConvertToPoint(xPos, yPos, Data.CurrentPoint.Z);

	//dieu khien EndEffector
	if (wPos != Data.WPosition)
	{
		Data.WPosition = wPos;
		EndEffector.Servo(wPos);
		Data.IsExecutedGcode = true;
	}

	if (Tool.CheckingDesiredPoint(pointBuffer) == false) return;

	if (CircleInterpolation(i, j, _clockwise) == false) return;

	Data.IsExecutedGcode = true;
	Stepper.Running();
	NumberSegment = 0;
}

void MotionClass::G4(float p)
{
	Tool.SetTimeDelay(p);
}

void MotionClass::G6(float angle1, float angle2, float angle3, float wPos)
{
	if (wPos != Data.WPosition)
	{
		Data.WPosition = wPos;
		EndEffector.Servo(wPos);
		Data.IsExecutedGcode = true;
	}

	Angle nextAngle;
	nextAngle.Theta1 = angle1;
	nextAngle.Theta2 = angle2;
	nextAngle.Theta3 = angle3;

	if (Tool.CheckingDesiredAngle(nextAngle) == false) return;

	Point pointBuffer;
	DeltaKinematics.ForwardKinematicsCalculations(nextAngle, pointBuffer);
	if (Tool.CheckingDesiredPoint(pointBuffer) == false) return;
	float moving_time = Tool.CalDistance2Point(Data.CurrentPoint, pointBuffer) / Data.Velocity;

	UploadSegment(Data.CurrentAngle, nextAngle, moving_time);

	Data.CurrentPoint = pointBuffer;
	Data.CurrentAngle = nextAngle;

	Data.IsExecutedGcode = true;
	Stepper.Running();
}

void MotionClass::G28()
{
	Stepper.IsRunningHome = true;

	Data.WPosition = 0;
	EndEffector.Servo(Data.WPosition);

	Planner.AddHomeSegment();
	Data.IsExecutedGcode = true;

	SetHomePosition();
	Stepper.EnableStepper();
	Stepper.Running();
}

bool MotionClass::LinearInterpolation()
{
	float distance2Point = Tool.CalDistance2Point(Data.CurrentPoint, Data.DesiredPoint);

	if (distance2Point == 0)
	{
		Data.IsExecutedGcode = true;
		return false;
	}

	Angle angle_;
	DeltaKinematics.InverseKinematicsCalculations(Data.DesiredPoint, angle_);

	if (!Tool.CheckingDesiredAngle(angle_))
	{
		return false;
	}
	
	NumberSegment = floorf(distance2Point / Data.MMPerLinearSegment);

	if (NumberSegment < 1)
		NumberSegment = 1;
	if (NumberSegment < 2)
		{
			Planner.one_seg_flag = true;
		}
	else
		{
			Planner.one_seg_flag = false;
		}

	float tbuffer;
	Angle lastAngle = Data.CurrentAngle;
	Angle currentAngle;

	//----------------------------------------------------------------
	V_planner.plan(distance2Point);
	V_planner.lastV = V_planner.V_atPoint_Cal(0);
	//----------------------------------------------------------------

	float mm_per_seg = distance2Point / NumberSegment;
	for (uint16_t i = 1; i <= NumberSegment; i++)
	{
		tbuffer = (float)i / NumberSegment;
		Point pointBuffer = Tool.GetPointInLine(Data.CurrentPoint, Data.DesiredPoint, tbuffer);
		DeltaKinematics.InverseKinematicsCalculations(pointBuffer, currentAngle);
		//----------------------------------------------------------------
		float currentV = V_planner.V_atPoint_Cal((float) mm_per_seg*i);
		float moving_time;
		if (!Planner.one_seg_flag)
			{
				moving_time = V_planner.V_Moving_Time_Cal(mm_per_seg, V_planner.lastV, currentV);
			}
		else
			{
				moving_time = mm_per_seg / Data.BeginEndVelocity;
			}
		V_planner.lastV = currentV;
		V_planner.T += moving_time;
		//----------------------------------------------------------------
		UploadSegment(lastAngle, currentAngle, moving_time);
		lastAngle = currentAngle;
	}
	//----------------------------------------------------------------
	V_planner.T = 0;
	//----------------------------------------------------------------
	Data.CurrentPoint = Data.DesiredPoint;
	Data.CurrentAngle = currentAngle;

	return true;
}

bool MotionClass::CircleInterpolation(float i, float j, bool clockwise)
{
	if (i == 0 && j == 0)
	{
		Data.IsExecutedGcode = true;
		return false;
	}

	float 	o_x = Data.CurrentPoint.X + i,
			o_y = Data.CurrentPoint.Y + j,
			radius = sqrt(pow(i, 2) + pow(j, 2)),
			angle_Current, angle_Desired;

	angle_Current = acosf(-i / radius);
	if (j > 0)
		angle_Current = -angle_Current;

	angle_Desired = acosf((Data.DesiredPoint.X - o_x) / radius);
	if (Data.DesiredPoint.Y - o_y <= 0)
		angle_Desired = -angle_Desired;


	float angular_travel = angle_Desired - angle_Current;
	if (angular_travel < 0) angular_travel += 2.0 * PI;
	if (clockwise) angular_travel -= 2.0 * PI;

	if (angular_travel > -0.01 && angular_travel < 0.01)
		angular_travel = 0;

	if (angular_travel == 0 && abs(Data.CurrentPoint.X - Data.DesiredPoint.X) < 0.4 && abs(Data.CurrentPoint.Y - Data.DesiredPoint.Y) < 0.4)
	{
		if (clockwise)
		{
			angular_travel = -2.0 * PI;
		}
		else
		{
			angular_travel = 2.0 * PI;
		}
	}

	float flat_mm = radius * abs(angular_travel);

	NumberSegment = floorf(flat_mm / Data.MMPerArcSegment);

	if (NumberSegment < 7 && NumberSegment > 3)
	{
		NumberSegment = floorf(flat_mm * 2 / Data.MMPerArcSegment);
	}
	else if (NumberSegment <= 3)
	{
		NumberSegment = floorf(flat_mm * 4 / Data.MMPerArcSegment);
	}

	if (NumberSegment < 7)
	{
		return false;
	}

	float theta_per_segment = angular_travel / NumberSegment;
	float mm_per_seg = flat_mm / NumberSegment;

	Angle lastAngle = Data.CurrentAngle;
	Angle currentAngle;

	Point endPoindInCircle = Tool.GetPointInCircle(o_x, o_y, radius, angle_Current + angular_travel);
    float distance2Point = Tool.CalDistance2Point(endPoindInCircle, Data.DesiredPoint);

	if (distance2Point > 0.5)
	{
		return false;
	}

	//----------------------------------------------------------------
	V_planner.plan(flat_mm);
	V_planner.lastV = V_planner.V_atPoint_Cal(0);
	//----------------------------------------------------------------

	for (uint16_t i = 1; i <= NumberSegment; i++)
	{
		Point pointBuffer;
		if (i == NumberSegment)
		{
			pointBuffer = Data.DesiredPoint;
		}
		else
		{
			pointBuffer = Tool.GetPointInCircle(o_x, o_y, radius, angle_Current + (float)i * theta_per_segment);
		}

		if (!DeltaKinematics.InverseKinematicsCalculations(pointBuffer, currentAngle)) return false;
		//----------------------------------------------------------------
		float currentV = V_planner.V_atPoint_Cal((float) mm_per_seg*i);
		float moving_time = V_planner.V_Moving_Time_Cal(mm_per_seg, V_planner.lastV, currentV);
		V_planner.lastV = currentV;
		V_planner.T += moving_time;
		//----------------------------------------------------------------
		UploadSegment(lastAngle, currentAngle, moving_time);
		lastAngle = currentAngle;
	}
	//----------------------------------------------------------------
	V_planner.T = 0;
	//----------------------------------------------------------------
	Data.CurrentPoint = Data.DesiredPoint;
	Data.CurrentAngle = currentAngle;

	return true;
}

void MotionClass::UploadSegment(Angle angle1, Angle angle2, float timeMove)
{
	float offset[3];
	offset[0] = angle2.Theta1 - angle1.Theta1;
	offset[1] = angle2.Theta2 - angle1.Theta2;
	offset[2] = angle2.Theta3 - angle1.Theta3;

	Planner.AddSegment(offset, timeMove);
}

void MotionClass::SetHomePosition()
{
	Angle homeAngle; 

	homeAngle.Theta1 = THETA1_HOME_POSITION;
	homeAngle.Theta2 = THETA2_HOME_POSITION;
	homeAngle.Theta3 = THETA3_HOME_POSITION;

	Data.DesiredPoint = Data.HomePosition;
	Data.CurrentPoint = Data.HomePosition;
	Data.CurrentAngle = homeAngle;
	Data.WPosition = 180;
}

MotionClass Motion;

