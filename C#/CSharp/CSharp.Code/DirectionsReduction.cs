// Directions Reduction
// https://www.codewars.com/kata/550f22f4d758534c1100025a
// Author: Rafał Klinowski

namespace CSharp.Code;

using System.Collections.Generic;

public class DirectionsReduction
{
	public static string[] dirReduc(string[] arr)
	{
		var list = new List<string>(arr);
		
		for (int i = 0; i < list.Count - 1; i++)
		{
			if (list[i] == "NORTH" && list[i + 1] == "SOUTH" || list[i] == "SOUTH" && list[i + 1] == "NORTH" || list[i] == "EAST" && list[i + 1] == "WEST" || list[i] == "WEST" && list[i + 1] == "EAST")
			{
				list.RemoveRange(i, 2);
				i = -1;
			}
		}
		return list.ToArray();
	}
}