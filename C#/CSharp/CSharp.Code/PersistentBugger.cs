namespace CSharp.Code;

using System.Linq;

public class PersistentBugger
{
	public static int Persistence(long n)
	{
		int result = 0;

		while (n > 9)
		{
			n = n.ToString().Select(x=>x-'0').Aggregate(1, (x, y) => x * y);
			result++;
		}

		return result;
	}
	
	public static int PersistenceV2(long n)
	{
		int result = 0;

		while (n > 9)
		{
			var digits = n.ToString().Select(x=>x-'0').ToArray();
			
			long product = 1;

			for (int i = 0; i < digits.Length; i++)
			{
				product*=digits[i];
			}

			n = product;
			result++;
		}

		return result;
	}
}