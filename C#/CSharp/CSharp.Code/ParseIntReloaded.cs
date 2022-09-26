// parseInt() reloaded
// https://www.codewars.com/kata/525c7c5ab6aecef16e0001a5
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;
using System.Collections.Generic;

public class ParseIntReloaded
{
	public static string[] Digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
	public static string[] Teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
	public static string[] Tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
	public static string[] Multipliers = { "hundred", "thousand", "million" };
	public static string Delimiter = "and";
	
	// TokenType helps us to determine the type of the token when going through them one-by-one.
	// It also helps us discard the unwanted Delimiter-type tokens immediately.
	public enum TokenType
	{
		Delimiter,	// "and"
		Numeric,	// "one", "two", "three", ...
		Multiplier	// "hundred", "thousand", ...
	}

	// Determines the type of a specific token.
	// Examples: "fifty-five" -> Numeric, "and" -> Delimiter, "hundred" -> Multiplier
	public static TokenType GetTokenType(string token)
	{
		string trimmed = token.Trim();

		if (trimmed.Equals(Delimiter))
		{
			return TokenType.Delimiter;
		}

		if (Array.IndexOf(Multipliers, trimmed) >= 0)
		{
			return TokenType.Multiplier;

		}
		
		return TokenType.Numeric;
	}

	// Returns the numerical representation of a single token.
	// Examples: "one" -> 1, "twenty" -> 20, "hundred" -> 100, "fifty-five" -> 50 + 5 = 55
	public static int StringToNumber(string s)
	{
		if (s.Equals(Multipliers[0]))
		{
			return 100;
		}
		if (s.Equals(Multipliers[1]))
		{
			return 1000;
		}
		if (s.Equals(Multipliers[2]))
		{
			return 1000000;
		}

		for (int i = 0; i < 10; ++i)
		{
			if (s.Equals(Digits[i]))
			{
				return i;
			}
		}
		
		for (int i = 0; i < 10; ++i)
		{
			if (s.Equals(Teens[i]))
			{
				return 10 + i;
			}
		}

		// eg. fifty-five
		bool containsDash = s.Contains('-');
		
		for (int i = 0; i < 8; i++)
		{
			if (containsDash)
			{
				string[] subtokens = s.Split('-');
				return StringToNumber(subtokens[0]) + StringToNumber(subtokens[1]);
			}
			else if (s.Equals(Tens[i]))
			{
				return (i + 2) * 10;
			}
		}

		return -1;
	}
	
	public static int ParseInt(string s)
	{
		// Split the input string into tokens, ignores "and".
		// Example: one hundred and fifty-five => [one, hundred, fifty-five]
		var tokens = new List<(string Token, TokenType TokenType)>();
		string[] split = s.Split(' ');
		
		foreach (var token in split)
		{
			var tokenType = GetTokenType(token);

			if (tokenType != TokenType.Delimiter)
			{
				tokens.Add((token, GetTokenType(token)));
			}
		}

		int result = 0;
		int partialResult = 0;

		// Calculate the result token-by-token.
		for (int i = 0; i < tokens.Count; i++)
		{
			var token = tokens[i];
			int parsedValue = StringToNumber(token.Token);

			if (token.TokenType == TokenType.Numeric && partialResult == 0)
			{
				// First number in a sequence.
				partialResult += parsedValue;
			}
			else if (token.TokenType == TokenType.Numeric && i < tokens.Count - 1 && tokens[i+1].Token.Equals(Multipliers[1]))
			{
				// Special case, eg. one hundred and fifty-five thousand five hundred and fifty-five.
				partialResult += parsedValue;
			}
			else if (token.TokenType == TokenType.Numeric)
			{
				// Second number in a sequence (ends the previous sequence).
				result += partialResult;
				partialResult = parsedValue;
			}
			else if (token.TokenType == TokenType.Multiplier)
			{
				// Multiplier, eg. hundred, thousand, million.
				partialResult *= parsedValue;
			}
		}

		// If there is a partial result left (usually the last numeric value), add it to the result.
		if (partialResult != 0)
		{
			result += partialResult;
		}
		
		return result;
	}
}