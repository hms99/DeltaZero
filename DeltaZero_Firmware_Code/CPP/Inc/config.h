#ifndef _CONFIG_H_
#define _CONFIG_H_
//Delta Model Use
#define DELTA_ZERO

#define BAUDRATE 115200

#define VACUUM
#ifdef VACUUM
 #define TIME_DELAY_TO_DROP	400 //ms
#endif // VACUUM

//Bresenham line drawing algorithm
#define MM_PER_LINEAR_SEGMENT	8			//mm
#define MM_PER_ARC_SEGMENT	8			//mm
#define NUMBER_PER_BEZIER_SEGMENT 30	//segment

#define DEFAULT_ACCELERATION 100.0				//mm^2/s
#define DEFAULT_VELOCITY 150.0					//mm/s

#define DEFAULT_MAX_VELOCITY 1000.0			//mm/s
#define DEFAULT_MAX_ACCELERATION 2000.0			//mm^2/s

#define INTERRUPT_CYCLE_MIN		1000.0f  //165 us

#define DEFAULT_BEGIN_VELOCITY 60			//mm/s
#define DEFAULT_END_VELOCITY 60		//mm/s

#define DEFAULT_ENTRY_VELOCITY 20			//mm/s
#define DEFAULT_EXIT_VELOCITY 20			//mm/s

#define DEFAULT_MOVING_HOME_SPEED 15			//deg/s //10

#define THETA1_MAX_POSITION	90				//deg
#define THETA2_MAX_POSITION	90
#define THETA3_MAX_POSITION	90

#define REVERSE_DIRECTION

#endif
