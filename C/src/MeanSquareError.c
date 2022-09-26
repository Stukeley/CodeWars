// Mean Square Error
// https://www.codewars.com/kata/51edd51599a189fe7f000015
// Created by Rafał Klinowski on 24.09.2022.
//
#include <stddef.h>

double mean_square_error(size_t n, const int a[n], const int b[n]) {
	if (n == 0) {
        return 0;
    }
    
    double result = 0.0;
    
    for (size_t i = 0; i < n; i++) {
		int difference = a[i] - b[i];
        result += difference * difference;
    }
    
    result /= n;
    
    return result;
}