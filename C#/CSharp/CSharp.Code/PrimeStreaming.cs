// Prime Streaming (PG-13)
// https://www.codewars.com/kata/5519a584a73e70fa570005f5
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PrimeStreaming
{
	public static IEnumerable<int> Stream()
	{
		// Limit of numbers to check, not primes.
		const int limit = 982_451_654;
		int limitSqrt = (int)Math.Sqrt(limit);

		var primes = new BitArray(limit, true)
		{
			[0] = false,
			[1] = false
		};

		for (int i = 2; i < limitSqrt; i++)
		{
			if (primes[i])
			{
				for (int j = i * i; j < limit && j > 0; j += i)
				{
					primes[j] = false;
				}
			}
		}

		for (int index = 0; index < limit; index++)
		{
			if (primes[index])
			{
				yield return index;
			}
		}
	}

	public static IEnumerable<int> StreamV2()
	{
		// Limit of numbers to check, not primes.
		const int limit = 982_451_654;

		var primes = new BitArray(limit, true)
		{
			[0] = false,
			[1] = false
		};

		for (int i = 2; i < limit; i++)
		{
			if (primes[i])
			{
				yield return i;
				
				for (int j = i * i; j < limit; j += i)
				{
					// We have to check for the overflow of 'j', so that we don't reference a negative index.
					if (j < 0)
					{
						break;
					}
					primes[j] = false;
				}
			}
		}
	}

	public static IEnumerable<int> StreamV3()
	{
		// Limit of numbers to check, not primes.
		const int limit = 982_451_654;

		var primes = new BitArray(limit, true)
		{
			[0] = false,
			[1] = false
		};

		for (int i = 2; i < limit; i++)
		{
			if (primes[i])
			{
				for (int j = i * i; j < limit; j += i)
				{
					// We have to check for the overflow of 'j', so that we don't reference a negative index.
					if (j < 0)
					{
						break;
					}
					primes[j] = false;
				}
				
				yield return i;
			}
		}
	}

	public static IEnumerable<int> StreamV4()
	{
		// Limit of numbers to check, not primes.
		const int limit = 982_451_654;

		var primes = new BitArray(limit, true)
		{
			[0] = false,
			[1] = false
		};

		for (int i = 2; i * i < limit; i++)
		{
			if (primes[i])
			{
				for (int j = i * i; j < limit; j += i)
				{
					// We have to check for the overflow of 'j', so that we don't reference a negative index.
					if (j < 0)
					{
						break;
					}
					primes[j] = false;
				}
			}
		}

		return primes.Cast<bool>().Select((b, i) => b ? i : 0).Where(i => i != 0).Select(i => i);
	}
}