//
// Created by Rafał Klinowski on 24.09.2022.
//
int score(const int dice[5]) {
	int score = 0;
    int count[7] = {0, 0, 0, 0, 0, 0, 0};
    
    for (int i = 0; i < 5; i++) {
        count[dice[i]]++;
    }
    
    for (int i = 1; i < 7; i++) {
        if (count[i] >= 3) {
            if (i == 1) {
                score += 1000;
            } else {
                score += i * 100;
            }
            
            count[i] -= 3;
        }
    }
    
    score += count[1] * 100;
    score += count[5] * 50;
    
    return score;
}