/*
 * singleServo.cpp
 *
 *  Created on: May 28, 2022
 *      Author: MINE
 */

#include "singleServo.h"

void singleServo::Init() 
{
	HAL_TIM_PWM_Start(&htim1, TIM_CHANNEL_1);
	toPosition(0);
	velocity_Stepper(Data.speed_loader);
}

void singleServo::toPosition(int position) 
{
	uint16_t luong_xung_can_xuat = (690 * position)/360 + 230 - 1;
	__HAL_TIM_SET_COMPARE(&htim1, TIM_CHANNEL_1, luong_xung_can_xuat);
}
void singleServo::velocity_Stepper(float velocity) 
{
	uint16_t luong_xung_tuong_ung;
	bool direction = true;
	
	if (velocity < 0)
	{
		direction = false;
		velocity = velocity * (-1);
	}

	if (direction)
	{
		WRITE(DIR_LOADER_PIN, RESET); 
	}
	else
	{
		WRITE(DIR_LOADER_PIN, SET); 
	}

	if (velocity != 0)
	{
		luong_xung_tuong_ung = (uint16_t) TIME_TO_PULSE * (D * PI)/(resolution*ratio*velocity) - 1;
		HAL_TIM_Base_Start_IT(&htim4);
		HAL_TIM_OC_Start_IT(&htim4, TIM_CHANNEL_3);
		__HAL_TIM_SET_AUTORELOAD(&htim4, luong_xung_tuong_ung);
		__HAL_TIM_SET_COMPARE(&htim4, TIM_CHANNEL_3, luong_xung_tuong_ung/2);
		TIM4->EGR = TIM_EGR_UG;
	}
	else
	{
		luong_xung_tuong_ung = 0;
		HAL_TIM_Base_Stop_IT(&htim4);
		HAL_TIM_OC_Stop_IT(&htim4, TIM_CHANNEL_3);
	}
}
singleServo servo;


