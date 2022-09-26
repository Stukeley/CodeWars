// Count IP Addresses
// https://www.codewars.com/kata/526989a41034285187000de4
// Author: Rafał Klinowski

namespace CSharp.Code;

using System.Linq;

public class CountIPAddresses
{
	public static long IpsBetween(string start, string end)
	{
		long startNum = start.Split('.').Select(long.Parse).Aggregate((x, y) => x * 256 + y);
		long endNum = end.Split('.').Select(long.Parse).Aggregate((x, y) => x * 256 + y);
		
		return endNum - startNum;
	}
}