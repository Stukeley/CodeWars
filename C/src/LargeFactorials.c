// Large Factorials
// https://www.codewars.com/kata/557f6437bf8dcdd135000010
// Created by Rafał Klinowski on 24.09.2022.
//
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *factorial(int n) {
	if (n < 0) {
		return "";
	}
	
	int resultSize = 1;
	int resultArray[1000] = {0};
	
	resultArray[0] = 1;
	
	for (int i = 2; i <= n; i++) {
		int carry = 0;
		
		for (int j = 0; j < resultSize; j++) {
			int temp = resultArray[j] * i + carry;
			resultArray[j] = temp % 10;
			carry = temp / 10;
		}
		
		while (carry > 0) {
			resultArray[resultSize] = carry % 10;
			carry /= 10;
			resultSize++;
		}
	}
	
	char *result = (char*)calloc(resultSize + 1, sizeof(char));
	
	for (int i = 0; i < resultSize; i++) {
		result[i] = resultArray[resultSize - i - 1] + '0';
	}
	
	return result;
}