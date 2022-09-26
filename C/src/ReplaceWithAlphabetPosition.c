// Replace With Alphabet Position
// https://www.codewars.com/kata/546f922b54af40e1e90001da
// Created by Rafał Klinowski on 23.09.2022.
//
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

// returned string has to be dynamically allocated and will be freed by the caller
char *alphabet_position(const char *text) {

    char* result = (char*)malloc(1000);
    
    int i = 0;
    
    while (text[i] != '\0')
    {
        if (text[i] >= 'a' && text[i] <= 'z')
        {
            sprintf(result, "%s%d ", result, text[i] - 'a' + 1);
        }
        else if (text[i] >= 'A' && text[i] <= 'Z')
        {
            sprintf(result, "%s%d ", result, text[i] - 'A' + 1);
        }
        i++;
    }
    
    result[strlen(result) - 1] = '\0';
    
    return result;
}