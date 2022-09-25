//
// Created by Rafał Klinowski on 23.09.2022.
//
#pragma warning(disable: 4996)
#include <stdlib.h>
#include <string.h>
#include <stdio.h>

void appendToString(char* str, char* format, int value, char* delimiter) {
	char* temp = (char*)calloc(20, sizeof(char));
	sprintf(temp, format, value);
	strcat(str, temp);
	free(temp);
	strcat(str, delimiter);
}

char* formatDuration (int n) {
	char* result = (char*)calloc(58, sizeof(char));
	char* commaDelimiter = ", ";
	char* andDelimiter = " and ";
	char* emptyDelimiter = "";

	if (n==0) {
		result[0] = 'n';
		result[1] = 'o';
		result[2] = 'w';
		result[3] = '\0';
	}
	else {
		int years = n / 31536000;
		int days = (n % 31536000) / 86400;
		int hours = (n % 86400) / 3600;
		int minutes = (n % 3600) / 60;
		int seconds = n % 60;

		int countOfElements = (years > 0) + (days > 0) + (hours > 0) + (minutes > 0) + (seconds > 0);

		if (years > 0) {
			char* delimiter = 0;

			if (countOfElements > 2) {
				delimiter=commaDelimiter;
			}
			else if (countOfElements == 2) {
				delimiter=andDelimiter;
			}
			else {
				delimiter = emptyDelimiter;
			}

			if (years == 1) {
				appendToString(result, "%d year", years, delimiter);
			}
			else {
				appendToString(result, "%d years", years, delimiter);
			}

			--countOfElements;
		}

		if (days > 0) {
			char* delimiter = 0;

			if (countOfElements > 2) {
				delimiter=commaDelimiter;
			}
			else if (countOfElements == 2) {
				delimiter=andDelimiter;
			}
			else {
				delimiter = emptyDelimiter;
			}

			if (days == 1) {
				appendToString(result, "%d day", days, delimiter);
			}
			else {
				appendToString(result, "%d days", days, delimiter);
			}

			--countOfElements;
		}

		if (hours > 0) {
			char* delimiter = 0;

			if (countOfElements > 2) {
				delimiter=commaDelimiter;
			}
			else if (countOfElements == 2) {
				delimiter=andDelimiter;
			}
			else {
				delimiter = emptyDelimiter;
			}

			if (hours == 1) {
				appendToString(result, "%d hour", hours, delimiter);
			}
			else {
				appendToString(result, "%d hours", hours, delimiter);
			}

			--countOfElements;
		}

		if (minutes > 0) {
			char* delimiter = 0;

			if (countOfElements > 2) {
				delimiter=commaDelimiter;
			}
			else if (countOfElements == 2) {
				delimiter=andDelimiter;
			}
			else {
				delimiter = emptyDelimiter;
			}

			if (minutes == 1) {
				appendToString(result, "%d minute", minutes, delimiter);
			}
			else {
				appendToString(result, "%d minutes", minutes, delimiter);
			}

			--countOfElements;
		}

		if (seconds > 0) {
			char* delimiter = 0;

			if (countOfElements > 2) {
				delimiter=commaDelimiter;
			}
			else if (countOfElements == 2) {
				delimiter=andDelimiter;
			}
			else {
				delimiter = emptyDelimiter;
			}

			if (seconds == 1) {
				appendToString(result, "%d second", seconds, delimiter);
			}
			else {
				appendToString(result, "%d seconds", seconds, delimiter);
			}

			--countOfElements;
		}
	}

	return result;
}