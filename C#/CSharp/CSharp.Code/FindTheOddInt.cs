// Find the odd int
// https://www.codewars.com/kata/54da5a58ea159efa38000836
// Author: Rafał Klinowski

namespace CSharp.Code;

using System.Linq;

public class FindTheOddInt
{
	public static int find_it(int[] seq) 
	{
		return seq.Select(x => new { x, Count = seq.Count(y => y == x) }).First(x => x.Count % 2 == 1).x;
	}
}