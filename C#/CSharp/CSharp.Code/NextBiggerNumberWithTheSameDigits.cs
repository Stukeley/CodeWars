namespace CSharp.Code;

public class NextBiggerNumberWithTheSameDigits
{
	public static long NextBiggerNumber(long n)
	{
		if (n < 10)
		{
			return -1;
		}
		
		var digits = n.ToString().ToCharArray();
		int i = digits.Length - 1;

		while (i > 0 && digits[i - 1] >= digits[i])
		{
			--i;
		}

		if (i <= 0)
		{
			return -1;
		}
		
		int j = digits.Length - 1;
		while (digits[j] <= digits[i - 1])
		{
			--j;
		}
		
		char temp = digits[i - 1];
		digits[i - 1] = digits[j];
		digits[j] = temp;
		
		for (j = digits.Length - 1; i < j; i++, j--)
		{
			temp = digits[i];
			digits[i] = digits[j];
			digits[j] = temp;
			i++;
			j--;
		}
		
		return long.Parse(new string(digits));
	}
}