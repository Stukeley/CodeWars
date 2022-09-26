// Convert A Hex String To RGB
// https://www.codewars.com/kata/5282b48bb70058e4c4000fa7
// Created by Rafał Klinowski on 24.09.2022.
//
#include <stdlib.h>
#include <string.h>

typedef struct {
	int r, g, b;
} rgb;

rgb hex_str_to_rgb(const char *hex_str) {
	rgb result;
	char byte[3];
	
	memcpy(byte, hex_str+1, 2);
	result.r = strtol(byte, 0, 16);
	memcpy(byte, hex_str+3, 2);
	result.g = strtol(byte, 0, 16);
	memcpy(byte, hex_str+5, 2);
	result.b = strtol(byte, 0, 16);

	return result;
}