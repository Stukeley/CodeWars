// Sum of Intervals
// https://www.codewars.com/kata/52b7ed099cdc285c300001cd
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;
using System.Linq;

public class SumOfIntervals
{
	public static int SumIntervals((int, int)[] intervals)
	{
		int result = 0;

		if (intervals.Length == 0)
		{
			return result;
		}
		
		var sortedIntervals = intervals.OrderBy(x => x.Item1).ToArray();
		
		var currentInterval = sortedIntervals[0];
		
		for (int i = 1; i < sortedIntervals.Length; i++)
		{
			var nextInterval = sortedIntervals[i];
			
			if (nextInterval.Item1 <= currentInterval.Item2)
			{
				currentInterval = (currentInterval.Item1, Math.Max(currentInterval.Item2, nextInterval.Item2));
			}
			else
			{
				result += currentInterval.Item2 - currentInterval.Item1;
				currentInterval = nextInterval;
			}
		}
		
		result += currentInterval.Item2 - currentInterval.Item1;
		
		return result;
	}
}