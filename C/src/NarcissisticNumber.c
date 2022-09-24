//
// Created by Rafał Klinowski on 23.09.2022.
//

#include <stdbool.h>

int myPow(int base, int exponent)
{
    int result = 1;
    for (int i = 0; i < exponent; ++i)
    {
        result *= base;
    }
    return result;
}

bool narcissistic(int num)
{
    int sum = 0;
    int digits = 0;
    int temp = num;
    
    while (temp > 0)
    {
        temp /= 10;
        digits++;
    }
    
    temp = num;

    while (temp > 0)
    {
        int digit = temp % 10;
        sum += myPow(digit, digits);
        temp /= 10;
    }
    
    if (num == sum)
    {
        return true;
    }
    else
    {
        return false;
    }
}