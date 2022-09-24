﻿#include <string.h>

char* digits[] = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
char* teens[] = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
char* tens[] = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

int matchToken(char* token)
{
    if (!strcmp(token, "and"))
    {
        return 0;
    }

    int containsDash = 0;

    for (int i = 0; i < strlen(token); i++)
    {
        if (token[i] == '-')
        {
            containsDash = 1;
            break;
        }
    }

    for (int i = 0; i < 10; i++)
    {
        if (!strcmp(token, digits[i]))
        {
            return i;
        }
    }

    for (int i = 0; i < 10; ++i)
    {
        if (!strcmp(token, teens[i]))
        {
            return i + 10;
        }
    }

    for (int i = 0; i < 8; ++i)
    {
        if (containsDash)
        {
            char first[20], second[20];
            int i = 0;
            while (token[i] != '-')
            {
                first[i] = token[i];
                ++i;
            }
            first[i++] = '\0';

            int j = 0;
            while (token[i] != '\0')
            {
                second[j++] = token[i++];
            }
            second[j] = '\0';

            return matchToken(first) + matchToken(second);

        }
        else if (!strcmp(token, tens[i]))
        {
            return (i + 2) * 10;
        }
    }

    return -1;
}

int identifyNumberPattern(const char* number) {
    int pattern = 0;

    char* firstHundred = strstr(number, "hundred");

    if (firstHundred != 0) {
        ++pattern;

        char* secondHundred = strstr(firstHundred + 1, "hundred");

        if (secondHundred != 0) {
            ++pattern;
        }
    }

    char* firstThousand = strstr(number, "thousand");

    if (firstThousand != 0) {
        ++pattern;
    }

    return pattern;
}

long parse_int(const char* number)
{
    long numberParsed = 0;

    // There are four possible patterns of numbers (up to 1 million only):
    // 1. A (eg. fifty-five = 55)
    // 2. A hundred B (e.g. five hundred and sixty-six = 566) || A thousand B (e.g. five thousand and sixty-six = 5066)
    // 3. A thousand B hundred C (e.g. three thousand five hundred sixty-six = 3566)
    // 4. A hundred B thousand C hundred D (e.g. two hundred fifty-five thousand five hundred sixty-six = 255566)

    // Algorithm:
    // 1. Identify the pattern
    // 2. Split the numbers.
    // 3. Parse the split numbers individually.
    // 4. Sum the numbers up.

    char* numberCopy = strdup(number);

    int pattern = identifyNumberPattern(numberCopy);

    if (pattern == 0) {
        numberParsed = matchToken(numberCopy);
    }
    else if (pattern == 1) {
        int a, b = 0;

        char* hundred = strstr(numberCopy, "hundred");

        char firstToken[20] = { 0 };
        memcpy(firstToken, numberCopy, (hundred - numberCopy - 1) * sizeof(char));

        a = matchToken(firstToken);

        int i = 0, j = 0;
        char subtoken[20];

        int lenOfHundred = strlen(hundred);

        for (i = 0; i < lenOfHundred + 1; ++i)
        {
            if (i == lenOfHundred || hundred[i] == ' ')
            {
                subtoken[j] = '\0';

                int value = matchToken(subtoken);

                if (value != -1)
                {
                    b += value;
                }

                j = 0;
            }
            else
            {
                subtoken[j++] = hundred[i];
            }
        }

        numberParsed = a * 100 + b;
    }
    else if (pattern == 2) {
        int a, b;

        char* thousand = strstr(numberCopy, "thousand");

        char firstToken[20] = { 0 };
        memcpy(firstToken, numberCopy, (thousand - numberCopy - 1) * sizeof(char));

        a = matchToken(firstToken);

        b = parse_int(thousand + 9);

        numberParsed = a * 1000 + b;
    }
    else if (pattern == 3) {
        int a, b;

        char* firstHundred = strstr(numberCopy, "hundred");

        char firstToken[20] = { 0 };
        memcpy(firstToken, numberCopy, (firstHundred - numberCopy - 1) * sizeof(char));

        a = matchToken(firstToken) * 100;

        char* thousand = strstr(numberCopy, "thousand");

        char secondToken[20] = {0};
        int amountToCopy = (thousand - firstHundred - 9) * sizeof(char);

        memcpy(secondToken, firstHundred + 8, amountToCopy > 0 ? amountToCopy : 1);    // !

        char* spaceInStr = strchr(secondToken, ' ');

        if (spaceInStr != 0)
        {
            b = matchToken(spaceInStr + 1);
        }
        else
        {
            b = matchToken(secondToken);
        }

        a = (a+b)*1000;

        b = parse_int(thousand + 9);

        numberParsed = a + b;
    }

    return numberParsed;
}