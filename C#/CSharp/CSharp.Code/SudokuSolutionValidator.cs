// Sudoku Solution Validator
// https://www.codewars.com/kata/529bf0e9bdf7657179000008
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;

public class SudokuSolutionValidator
{
	// The solution uses three loops with heavy nesting, but is still very fast due to the use of Span.
	public static bool ValidateSolution(int[][] board)
	{
		var span = board.AsSpan();

		// Bit hack. If the values do not repeat, the same bit in 'flag' won't be set twice.
		// For example, if we have 1, 2, 3, 4, 5, 6, 7, 8, 9, then the flag will be 0b1111111110.
		// But, if we have 1, 2, 3, 1 (flag 0b1110), then we will attempt to set an already set bit again, so we will return false.
		int flag = 0;

		// We need to check it in three ways:
		// 1. Check each row (0-8, 9-17, 18-26, etc)
		// 2. Check each column ({0,9,18,...}, {1,10,19,...}, {2,11,20,...}, etc)
		// 3. Check each 3x3 box ({0,1,2,9,10,11,18,19,20}, {3,4,5,12,13,14,21,22,23}, etc)
		for (int i = 0; i < span.Length; i++)
		{
			flag = 0;
			
			for (int j = 0; j < span[i].Length; j++)
			{
				int value = span[i][j];
				
				if (value == 0)
				{
					return false;
				}
				
				int bit = 1<<value;
				
				if ((flag & bit) != 0)
				{
					return false;
				}

				flag |= bit;
			}
		}

		// Zeroes and rows have been checked.
		// Now we need to check columns and boxes.
		for (int i = 0; i < span.Length; i++)
		{
			flag = 0;
			
			for (int j = 0; j < span[i].Length; j++)
			{
				int value = span[j][i];
				
				if (value == 0)
				{
					return false;
				}
				
				int bit = 1<<value;
				
				if ((flag & bit) != 0)
				{
					return false;
				}

				flag |= bit;
			}
		}
		
		// Columns have been checked.
		// Now we need to check boxes.
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				flag = 0;
				
				for (int k = 0; k < 3; k++)
				{
					for (int l = 0; l < 3; l++)
					{
						int value = span[i * 3 + k][j * 3 + l];
						
						if (value == 0)
						{
							return false;
						}
						
						int bit = 1<<value;
						
						if ((flag & bit) != 0)
						{
							return false;
						}

						flag |= bit;
					}
				}
			}
		}

		return true;
	}
}