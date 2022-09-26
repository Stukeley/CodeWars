// Unfinished
namespace CSharp.Code;

using System;
using System.Linq;
using System.Text;

public class DecodeSecretEnemyMessages
{
	public static string Decode(string p_what)
	{
		// Log:
		// Console.WriteLine(Encoder.Encode ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
		// bdhpF,82QsLirJejtNmzZKgnB3SwTyXG ?.6YIcflxVC5WE94UA1OoD70MkvRuPqHabdhpF,82QsLir
		
		// Console.WriteLine(Encoder.Encode ("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"));
		// dhpF,82QsLirJejtNmzZKgnB3SwTyXG ?.6YIcflxVC5WE94UA1OoD70MkvRuPqHabdhp
		
		// Console.WriteLine(Encoder.Encode ("!@#$%^&*()_+-")) -> !@#$%^&*()_+- => Special characters are not encoded, except for . , ? and space
		
		// Characters "abcdefghijklmnopqrstuvwxyz" encoded one by one:
		// bdfhjlnprtvxzBDFHJLNPRTVXZ
		// (each character +2, then uppercase)
		// (+2, +4, ...)
		
		// Characters "abcdefghijklmnopqrstuvwxyz" encoded in format "_a", "_b", ..., "_z":
		// dhlptxBFJNRVZ37,aeimquyCGK
		// (each character +3, then uppercase, then numbers, then symbols, then lowercase)
		// (+3, +6, ...)
		
		// Characters "abcdefghijklmnopqrstuvwxyz" encoded in format "__a", "__b", ..., "__z":
		// hpxFNV3,emuCKS08bjrzHPX5 g
		// (each character +7)
		// (+7, +14, ...)
		
		// Console.WriteLine(Encoder.Encode ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.,? "));
		// bhx,zWyLZ3pOGIhzeXTYtjAaDWiO8miYH 8Uk4XMwc1c,QXBTeK8CfPjfYTUdCGp  

		return "";
	}
}