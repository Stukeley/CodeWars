// Is a number prime?
// https://www.codewars.com/kata/5262119038c0985a5b00029f
// Created by Rafał Klinowski on 23.09.2022.
//
#include <stdbool.h>
#include <math.h>

bool is_prime(int num) {
    
    if (num < 2) {
        return false;
    }
    
    for (int i = 2; i <= sqrt(num); ++i) {
        if (num % i == 0) {
            return false;
        }
    }
    return true;
}