/*
 * serialObject.cpp
 *
 *  Created on: May 30, 2022
 *      Author: MINE
 */

#include <serialObject.h>

void serialObject::Init()
{
	for (uint8_t i = 0; i < RX_SIZE; i++)
	{
		this -> rxBuffer[i] = 32; //space
	}
	HAL_UART_Receive_DMA(&huart2, Serial.rxBuffer, RX_SIZE);
}

void serialObject::reset()
{
	Init();
}

bool serialObject::available()
{
	return received_Flag;
}

void serialObject::read_return(char* _return)
{
	received_Flag = false;
	strcpy(_return, read_string);
	reset_read_string();
}

void serialObject::reset_read_string()
{
	int len = (int)strlen(read_string);
	for (int i = 0; i < len; i ++)
	{
		read_string[i] = 0;
	}
}

void serialObject::print_char(const char* _buffer)
{
	memset(i_buffer, 0, strlen(i_buffer));
	strcpy(i_buffer,_buffer);
	strcat(i_buffer," ");
	uint8_t SIZE = strlen(i_buffer)-1;
	HAL_UART_Transmit(&huart2, (uint8_t*)i_buffer, SIZE, 1000);
}

void serialObject::print_int(int int_value)
{
	print_char((const char*)int_to_char(int_value));
}

void serialObject::print_float(float float_value)
{
	print_char((const char*)float_to_char(float_value));
}

void serialObject::respond_three_element(const char* key_words, float float_1, float float_2, float float_3)
{
	char string[TX_SIZE];
	strcpy(string, key_words);
	strcat(string," ");
	strcat(string, int_to_char((int)float_1));
	strcat(string," ");
	strcat(string, int_to_char((int)float_2));
	strcat(string," ");
	strcat(string, int_to_char((int)float_3));
	strcat(string,"\n");
	print_char(string);
}

void serialObject::respond_one_element(const char* key_words, float float_1)
{
	char string[TX_SIZE];
	strcpy(string, key_words);
	strcat(string," ");
	strcat(string, int_to_char((int)float_1));
	strcat(string,"\n");
	print_char(string);
}

char* serialObject::int_to_char(int int_value)
{
	memset(s_value, 0, strlen(s_value));
	itoa(int_value, s_value, 10);
	return s_value;
}

char* serialObject::float_to_char(float float_value)
{
	memset(s_value, 0, strlen(s_value));
	char after_dot[2];

	int int_value;
	int int_value_after_dot;
	if (float_value >= 0)
	{
		int_value = (int) floorf(float_value);
		int_value_after_dot = (int) floorf((float_value - int_value)*100);
	}
	else if (float_value < 0)
	{
		int_value = (int) ceilf(float_value);
		int_value_after_dot = (int) floorf((int_value - float_value)*100);
	}

	if (int_value_after_dot > 9)
	{
		itoa(int_value_after_dot, after_dot, 10);
	}
	else if (int_value_after_dot <= 9)
	{
		after_dot[0] = '0';
		char __buff[1];
		itoa(int_value_after_dot, __buff, 10);
		after_dot[1] = __buff[0];
	}

	itoa(int_value, s_value, 10);
	strcat(s_value,".");
	strcat(s_value,after_dot);
	return s_value;
}

void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{
	if (huart->Instance == USART2)
	{
		bool asterisk_flag = false;
		for (int i = 0; i < RX_SIZE; i++)
		{
			if (Serial.rxBuffer[i] == 42)//"*"
			{
				asterisk_flag = true;
			}
			if (!asterisk_flag)
			{
				Serial.read_string[i]=Serial.rxBuffer[i];
			}
			Serial.rxBuffer[i] = 0;
		}
		Serial.received_Flag = true;
	}
}
serialObject Serial;
