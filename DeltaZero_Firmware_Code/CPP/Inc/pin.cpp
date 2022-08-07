/*
 * pin.cpp
 *
 *  Created on: May 31, 2022
 *      Author: MINE
 */
#include "pin.h"

void WRITE(GPIO_TypeDef *GP, uint16_t Pin, GPIO_PinState State) 
{
	HAL_GPIO_WritePin(GP, Pin, State);
}

bool READ(GPIO_TypeDef *GP, uint16_t Pin) 
{
	bool read = HAL_GPIO_ReadPin(GP, Pin);
	return read;
}

