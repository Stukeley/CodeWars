// Sums of Perfect Squares
// https://www.codewars.com/kata/5a3af5b1ee1aaeabfe000084
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfSquares
{
	public static int FindNumberOfSquares(int n, int first)
	{
		// Assume the first root and go from there.
		int result = 1;
		n -= first * first;

		// If in any case (shouldn't ever happen) the first root we passed is too big, return int.MaxValue.
		if (n < 0)
		{
			return int.MaxValue;
		}

		// While the number is above zero:
		// 1. Get the first possible integer root, e.g. for 3622 it would be 60.
		// 2. Increment result (we found a perfect root), subtract the value from n, e.g. 3622 - 60^2 = 22.
		// 3. Repeat until we get to 0.
		while (n != 0)
		{
			int root = (int)Math.Sqrt(n);
			result++;
			n -= root * root;
		}

		return result;
	}
	
	public static int NSquaresFor(int n)
	{
		Console.WriteLine(n);
		
		// For n=1, result = 1. For n=2, result = 2.
		if (n < 3)
		{
			return n;
		}
		
		int perfectRoot = (int)Math.Sqrt(n);
		
		// If number is already a perfect square, return 1.
		if (perfectRoot * perfectRoot == n)
		{
			return 1;
		}

		var list = new List<int>();

		// Start from the first possible root (Sqrt(n)) and go down.
		// i will be the first assumed element in the sequence.
		// This will not exceed 32000 iterations in the most extreme cases (quite low).
		for (int i = (int)Math.Sqrt(n); i > 0; --i)
		{
			list.Add(FindNumberOfSquares(n, i));
		}

		// Select the lowest value out of all.
		// This is necessary in cases like n=18, where normally the result would be 3 (4^2+1^2+1^2),
		// but the correct answer is 2 (3^2+3^2).
		return list.Min();
	}
}