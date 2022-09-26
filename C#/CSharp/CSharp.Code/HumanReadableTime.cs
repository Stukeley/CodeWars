// Human Readable Time
// https://www.codewars.com/kata/52685f7382004e774f0001f7
// Author: Rafał Klinowski

namespace CSharp.Code;

public class HumanReadableTime
{
	public static string GetReadableTime(int seconds)
	{
		int hours = seconds / 3600;
		int minutes = (seconds % 3600) / 60;
		int secs = seconds % 60;
		
		return $"{hours:00}:{minutes:00}:{secs:00}";
	}
}