//
// Created by Rafa³ Klinowski on 23.09.2022.
//
#include <stdlib.h>
#include <stdio.h>

unsigned int sum_of_squares(unsigned int n) {

	printf("n = %d\n", n);
	
	if (n < 3) {
		return n;
	}

	int* squares = (int*)malloc((n + 1) * sizeof(int));

	int i = 1;
	
	for (i = 1; i < n; ++i) {
		int square = i * i;
		if (square > n) {
			break;
		}
		squares[i] = square;
	}

	unsigned int result = 0;
	unsigned int total = n;

	while (i >= 0 && total > 0) {
		if (squares[i] <= total) {
			total -= squares[i];
			result++;
		}
		else {
			--i;
		}
	}

	free(squares);

	printf("Ran to completion, result = %d\n", result);

	return result;
}

int main(int argc, char** argv)
{
	unsigned int result;
	
	result = sum_of_squares(1);
	result = sum_of_squares(2);
	result = sum_of_squares(4);
	result = sum_of_squares(16);
	result = sum_of_squares(15);
	
	result = sum_of_squares(12570000);
	
	return 0;
}