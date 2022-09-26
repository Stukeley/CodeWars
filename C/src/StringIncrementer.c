// String incrementer
// https://www.codewars.com/kata/54a91a4883a7de5d7800009c
// Created by Rafał Klinowski on 23.09.2022.
//
#include <stdlib.h>
#include <string.h>
#include <stdio.h>

char *incrementString(const char *str)
{
// allocate on the heap, memory will be freed
    char numberStr[100] = {0};
    int len = strlen(str);

    // find the last number in the string.
    for (int i = 0; i < len; ++i) 
    {
        if (str[i] >= '0' && str[i] <= '9') 
        {
            int j = 0;
            while (str[i] >= '0' && str[i] <= '9') 
            {
                numberStr[j] = str[i];
                ++i;
                ++j;
            }
            numberStr[j] = '\0';
        }
    }
    
    int lastNumberLen = strlen(numberStr);
    
    int zeroCount = 0;
    int z = 0;
    while (numberStr[z] != '\0') 
    {
        if (numberStr[z] == '0')
        {
            ++zeroCount;
        }
        else if (numberStr[z] == '9')
        {
            // Nine is the first non-zero number, and is followed by nines only, eg. "foobar0099" - cut one zero.
            int i = z + 1;
            short isNinesOnly = 1;
            
            while (numberStr[i] != '\0') 
            {
                if (numberStr[i] != '9')
                {
                    isNinesOnly = 0;
                    break;
                }
                ++i;
            }
            
            if (isNinesOnly)
            {
                --zeroCount;
            }
            break;
        }
        else
        {
            // Anything else, eg. "foobar027" - break.
            break;
        }
        ++z;
    }
    
    // Only zeroes, eg. "foobar000" - cut one zero.
    if (lastNumberLen == zeroCount)
    {
        --zeroCount;
    }
    
    int number = atoi(numberStr);
    ++number;
    
    char* result = calloc(100, sizeof(char));
    
    // Copy non-number characters.
    for (z = 0; z < len - lastNumberLen; ++z) 
    {
        result[z] = str[z];
    }

    // Add leading zeroes.
    for (int i = 0; i < zeroCount; ++i) {
        result[z++] = '0';
    }
    
    // Copy the rest of the number.
    sprintf(result, "%s%d", result, number);
    
    return result;
}