/*
 * singleServo.h
 *
 *  Created on: May 28, 2022
 *      Author: MINE
 */

#ifndef INC_SINGLESERVO_H_
#define INC_SINGLESERVO_H_

#define D 31 //duong kinh cua truc tai (mm)
#define resolution 200 //phan giai cua stepper
#define ratio 2 //ty so truyen cua bang tai
#define TIME_TO_PULSE 18000/2 //luong xung trong mot giay cap cho timer
#ifndef PI
#define PI 3.1415

#endif

#include "main.h"
#include <math.h>
#include "stm32f1xx_hal.h"
#include "pin.h"
#include "serialObject.h"
#include "Constants.h"

extern TIM_HandleTypeDef htim1;
extern TIM_HandleTypeDef htim4;

class singleServo
{
public:
	void Init();
	void toPosition(int position);
	void velocity_Stepper(float velocity);
};
extern singleServo servo;

#endif /* INC_SINGLESERVO_H_ */
