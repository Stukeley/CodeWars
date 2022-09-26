// RGB To Hex Conversion
// https://www.codewars.com/kata/513e08acc600c94f01000001
// Author: Rafał Klinowski

namespace CSharp.Code;

using System;

public class RgbToHexConversion
{
	public static string Rgb(int r, int g, int b)
	{
		r = Math.Clamp(r, 0, 255);
		g = Math.Clamp(g, 0, 255);
		b = Math.Clamp(b, 0, 255);

		return $"{r:X2}{g:X2}{b:X2}";
	}
}