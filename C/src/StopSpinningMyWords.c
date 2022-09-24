//
// Created by Rafał Klinowski on 23.09.2022.
//
#include <string.h>

//  do not allocate memory for return string
//  assign the value to the pointer "result"

void spin_words(const char *sentence, char *result) {

    int len = strlen(sentence);

    for (int i = 0; i < len; ++i) {
        
        char word[100] = {0};
        
        int j = i, k = 0;
        
        while (sentence[j] != ' ' && j < len) 
        {
            word[k++] = sentence[j++];
        }
        
        int wordLen = strlen(word);
        
        if (wordLen >= 5)
        {
            for (int l = wordLen - 1; l >= 0; --l) 
            {
                result[i++] = word[l];
            }
        }
        else
        {
            for (int l = 0; l < wordLen; ++l) 
            {
                result[i++] = word[l];
            }
        }
        
        result[i] = ' ';
    }
    
    result[len] = '\0';
}