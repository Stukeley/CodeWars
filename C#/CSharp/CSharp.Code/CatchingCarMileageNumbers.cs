// Catching Car Mileage Numbers
// https://www.codewars.com/kata/52c4dd683bfd3b434c000292
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;
using System.Collections.Generic;
using System.Linq;

public class CatchingCarMileageNumbers
{
	public static int IsInteresting(int number, List<int> awesomePhrases)
	{
		if (CheckIfNumberIsInteresting(number, awesomePhrases) == 2)
		{
			return 2;
		}

		if (CheckIfNumberIsInteresting(number + 1, awesomePhrases) == 2 || CheckIfNumberIsInteresting(number + 2, awesomePhrases) == 2)
		{
			return 1;
		}

		return 0;
	}
	
	private static int CheckIfNumberIsInteresting(int number, List<int> awesomePhrases)
	{
		if (number < 100)
		{
			return 0;
		}
		
		string numberString = number.ToString();
		
		// Any digit followed by all zeroes.
		if (!numberString.StartsWith('0') && numberString.Count(c=>c=='0') == numberString.Length - 1)
		{
			return 2;
		}
		
		// All digits are the same.
		if (numberString.Distinct().Count() == 1)
		{
			return 2;
		}
		
		{
			// The digits are sequential, incementing.
			int firstDigit = numberString[0] - '0';
			
			for (int i = 1; i<numberString.Length; i++)
			{
				// For incrementing sequences, 0 should come after 9, and not before 1, as in 7890.
				int currentDigit = numberString[i] - '0';
				if (currentDigit == 0)
				{
					currentDigit = 10;
				}
				
				if (currentDigit != firstDigit + i)
				{
					break;
				}
				
				if (i == numberString.Length - 1)
				{
					return 2;
				}
			}
		}
		
		{
			// The digits are sequential, decrementing.
			int firstDigit = numberString[0] - '0';
			
			for (int i = 1; i<numberString.Length; i++)
			{
				// For decrementing sequences, 0 should come after 1, and not before 9, as in 3210.
				int currentDigit = numberString[i] - '0';
				if (currentDigit != firstDigit - i)
				{
					break;
				}
				
				if (i == numberString.Length - 1)
				{
					return 2;
				}
			}
		}

		// The digits are a palindrome.
		if (numberString.SequenceEqual(numberString.Reverse()))
		{
			return 2;
		}
		
		// The digits match one of the values in the awesomePhrases array.
		if (awesomePhrases.Contains(number))
		{
			return 2;
		}
		
		return 0;
	}
}