//
// Created by Rafał Klinowski on 23.09.2022.
//
#include <stdio.h>
#include <string.h>

int myPow(int base, int exponent) {
    int result = 1;
    for (int i = 0; i < exponent; i++) {
        result *= base;
    }
    return result;
}

int digPow(int n, int p) {
    char str[100];
    
    sprintf(str, "%d", n);
    
    int len = strlen(str);
    int sum = 0;

    for (int i = 0; i < len; ++i) {
        int digit = str[i] - '0';
        sum += myPow(digit, p + i);
    }
    
    if (sum % n == 0) {
        return sum / n;
    }
    else {
        return -1;
    }
}