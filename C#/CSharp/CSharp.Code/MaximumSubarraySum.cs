// Maximum subarray sum
// https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;

public class MaximumSubarraySum
{
	public static int MaxSequence(int[] arr)
	{
		int maxSumSoFar = 0;
		int maxSum = 0;

		for (int i = 0; i < arr.Length; i++)
		{
			maxSumSoFar = Math.Max(0, maxSumSoFar + arr[i]);
			maxSum = Math.Max(maxSumSoFar, maxSum);
		}

		return maxSum;
	}
}