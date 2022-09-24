//
// Created by Rafał Klinowski on 23.09.2022.
//

// https://www.purplemath.com/modules/factzero.htm
long zeros(long n) {
    int numberOfZeroes = 0;
    
    for (int i = 5; n / i >= 1; i *= 5) {
        numberOfZeroes += n / i;
    }
    
    return numberOfZeroes;
}