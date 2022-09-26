// Ones and Zeros
// https://www.codewars.com/kata/578553c3a1b8d5c40300037c
// Created by Rafał Klinowski on 23.09.2022.
//
#include <stddef.h>

unsigned binary_array_to_numbers(const unsigned *bits, size_t count)
{
    unsigned decimal = 0;
    
    for (size_t i = 0; i < count; ++i)
    {
        decimal += bits[i] * (1 << (count - i - 1));
    }
    
    return decimal;
}