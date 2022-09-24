//
// Created by Rafał Klinowski on 23.09.2022.
//

#include <stddef.h>

long sum_two_smallest_numbers(size_t n, const int numbers[n]) {

    long min1 = numbers[0];
    long min2 = numbers[1];
    
    for (int i = 1; i < n; i++) {
        if (numbers[i] < min1) {
            min2 = min1;
            min1 = numbers[i];
        } else if (numbers[i] < min2) {
            min2 = numbers[i];
        }
    }
    
    return min1 + min2;
}