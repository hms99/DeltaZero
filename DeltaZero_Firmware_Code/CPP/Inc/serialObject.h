/*
 * serialObject.h
 *
 *  Created on: May 30, 2022
 *      Author: MINE
 */

#ifndef INC_SERIALOBJECT_H_
#define INC_SERIALOBJECT_H_

#define RX_SIZE 60
#define TX_SIZE 60
#include "main.h"
#include "Constants.h"
#include <string.h>
#include "stm32f1xx_hal.h"
#include <math.h>
#include <stdlib.h>

using namespace std;

extern UART_HandleTypeDef huart2;

class serialObject 
{
public:
	bool received_Flag = false;
	char read_string[RX_SIZE];
	uint8_t rxBuffer[RX_SIZE];
	char s_value[TX_SIZE];
	char i_buffer[TX_SIZE];

	void Init();
	void reset();

	bool available();
	void read_return(char* _return);
	
	void print_char(const char* _buffer);
	void print_int(int int_value);
	void print_float(float float_value);
	
	void respond_three_element(const char* key_words, float float_1, float float_2, float float_3);
	void respond_one_element(const char* key_words, float float_1);

	char* float_to_char(float float_value);
	char* int_to_char(int int_value);
	
	void reset_read_string();
} ;
extern serialObject Serial;
extern DMA_HandleTypeDef hdma_usart2_rx;

#endif /* INC_SERIALOBJECT_H_ */
