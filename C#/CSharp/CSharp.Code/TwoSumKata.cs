// Two Sum
// https://www.codewars.com/kata/52c31f8e6605bcc646000082
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;
using System.Collections.Generic;

public class TwoSumKata
{
	// O(n) complexity
	public static int[] TwoSum(int[] numbers, int target)
	{
		var dict = new Dictionary<int, int>();
		
		for (int i = 0; i < numbers.Length; i++)
		{
			var number = numbers[i];
			var complement = target - number;
			
			if (dict.ContainsKey(complement))
			{
				return new[] { dict[complement], i };
			}
			dict[number] = i;
		}
		
		return Array.Empty<int>();
	}
}