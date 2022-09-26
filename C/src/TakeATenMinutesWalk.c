// Take a Ten Minutes Walk
// https://www.codewars.com/kata/54da539698b8a2ad76000228
// Created by Rafał Klinowski on 23.09.2022.
//
#include <stdbool.h>

bool isValidWalk(const char *walk) 
{
    // Position relative to starting point.
    int posX = 0, posY = 0;
    int duration = 0;
    
    int i = 0;
    
    while (walk[i] != '\0') 
    {
        duration++;
        
        switch (walk[i]) {
            case 'n':
                posY++;
                break;
            case 's':
                posY--;
                break;
            case 'e':
                posX++;
                break;
            case 'w':
                posX--;
                break;
        }
        i++;
    }
    
    if (duration == 10 && posX == 0 && posY == 0) 
    {
        return true;
    }
    else 
    {
        return false;
    }
}