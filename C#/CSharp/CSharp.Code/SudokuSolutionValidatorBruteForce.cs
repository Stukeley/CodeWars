// Sudoku Solution Validator - Brute Force version
// https://www.codewars.com/kata/529bf0e9bdf7657179000008
// Author: Rafał Klinowski

namespace CSharp.Code;

using System.Collections.Generic;

public class SudokuSolutionValidatorBruteForce
{
	// Brute force (very badly optimized) solution.
	public static bool ValidateSolution_BruteForce(int[][] board)
	{
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				if (board[i][j] == 0 || !IsValid(board, i, j))
				{
					return false;
				}
			}
		}
        
        return true;
    }
	
    private static bool NotInRow(int[][] arr, int row)
    {
        var st = new HashSet<int>();
 
        for (int i = 0; i < 9; i++) 
        {
            if (st.Contains(arr[row][i]))
            {
                return false;
            }
            
            st.Add(arr[row][i]);
        }
        
        return true;
    }
 
    private static bool NotInCol(int[][] arr, int col)
    {
        var st = new HashSet<int>();
 
        for (int i = 0; i < 9; i++) 
        {
            if (st.Contains(arr[i][col]))
            {
                return false;
            }
            
            st.Add(arr[i][col]);
        }
        return true;
    }
 
    private static bool NotInBox(int[][] arr, int startRow, int startCol)
    {
        var st = new HashSet<int>();
 
        for (int row = 0; row < 3; row++) 
        {
            for (int col = 0; col < 3; col++) 
            {
                int curr = arr[row + startRow][col + startCol];

                if (st.Contains(curr))
                {
                    return false;
                }
                
                st.Add(curr);
            }
        }
        return true;
    }
 
    // Checks whether current row and current column and
    // current 3x3 box is valid or not
    private static bool IsValid(int[][] arr, int row, int col)
    {
        return NotInRow(arr, row) && NotInCol(arr, col) && NotInBox(arr, row - row % 3, col - col % 3);
    }
}