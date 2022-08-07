#include <stdlib.h>
#include <stdint.h>
#include <math.h>

using namespace std;

float BeginEndVelocity = 90;
float Velocity = 250;
float Acceleration = 100;
float MMPerLinearSegment = 8;
class Velocity_Planner_Class
{
	public:

		float T;

		void plan(float _distance2Point);
		float V_atPoint_Cal(float _length_at_point);
		float V_Moving_Time_Cal(float _length, float _lastV, float _currentV);
		float lastV = 0;
	private:
		float S1;
		float S2;
		float S3;

		float Ta;
		float Tb;

		float accel_a;
		float accel_b;
		bool case_delta;

		float road_length;
		float point_length;
		float V_desired;
		float V_atPoint;
		float V_begin;
		float V_end;
};
void Velocity_Planner_Class::plan(float _distance2Point)
{
	V_desired = Velocity;
	road_length = _distance2Point;

	V_begin = BeginEndVelocity;
	V_end 	= BeginEndVelocity;

	Ta = (V_desired - V_begin) / Acceleration;
	if (Ta > 0)
	{
		accel_a = Acceleration;
	}
	else if (Ta == 0)
	{
		accel_a = 0;
	}
	else if (Ta < 0)
	{
		accel_a = - Acceleration;
		Ta = - Ta;
	}

	Tb = (V_end - V_desired) / Acceleration;
	if (Tb > 0)
	{
		accel_b = Acceleration;
	}
	else if (Tb == 0)
	{
		accel_b = 0;
	}
	else if (Tb < 0)
	{
		accel_b = - Acceleration;
		Tb = - Tb;
	}

	S1 = (V_begin + V_desired) * Ta / 2;
	S2 = (V_end + V_desired) * Tb / 2;

	if (road_length > (S1 + S2))
	{
		S3 = road_length;
		S2 = S3 - S2;
		case_delta = false;
	}
	else if (road_length <= (S1 + S2))
	{
		V_desired = V_begin + accel_a * ((sqrt(V_begin * V_begin + accel_a * road_length) - V_begin) / accel_a);
		case_delta = true;
	}
}
float Velocity_Planner_Class::V_atPoint_Cal(float _length_at_point)
{
	float t ;
	point_length = _length_at_point;

	if (!case_delta)
	{
		if (point_length < S1)
		{
			t = sqrt(2 * point_length / accel_a);
			V_atPoint = V_begin + t * accel_a;
		}
		else if ((S1 < point_length)&&(point_length <= S2))
		{
			V_atPoint = V_desired;
		}
		else if ((S2 < point_length)&&(point_length <= S3))
		{
			t = (sqrt(V_desired * V_desired - 2 * accel_b * (S2 - point_length)) - V_desired) / accel_b;
			V_atPoint = V_desired + t * accel_b;
		}
	}
	else
	{
		if (point_length < road_length/2)
		{
			t = sqrt(2 * point_length / accel_a);
			V_atPoint = V_begin + t * accel_a;
		}
		else if (point_length >= road_length/2)
		{
			t = (sqrt(V_desired * V_desired - 2 * accel_b * (road_length/2 - point_length)) - V_desired) / accel_b;
			V_atPoint = V_desired + t * accel_b;
		}
	}
	return V_atPoint;
}
float Velocity_Planner_Class::V_Moving_Time_Cal(float _length, float _lastV, float _currentV)
{
	return (2 * _length / (_lastV + _currentV));
}

