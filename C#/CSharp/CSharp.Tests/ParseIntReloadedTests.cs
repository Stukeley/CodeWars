namespace CSharp.Tests;

using Code;
using NUnit.Framework;

[TestFixture]
public class ParseIntReloadedTests
{
	[Test]
	public void TestSampleCases()
	{
		Assert.AreEqual(1, ParseIntReloaded.ParseInt("one"));
		Assert.AreEqual(20, ParseIntReloaded.ParseInt("twenty"));
		Assert.AreEqual(246, ParseIntReloaded.ParseInt("two hundred forty-six"));
	}

	[Test]
	public void TestExtendedCases()
	{
		Assert.AreEqual(55, ParseIntReloaded.ParseInt("fifty-five"));
		Assert.AreEqual(500, ParseIntReloaded.ParseInt("five hundred"));
		Assert.AreEqual(155, ParseIntReloaded.ParseInt("one hundred and fifty-five"));
		Assert.AreEqual(5000, ParseIntReloaded.ParseInt("five thousand"));
		Assert.AreEqual(1055, ParseIntReloaded.ParseInt("one thousand and fifty-five"));
		Assert.AreEqual(1500, ParseIntReloaded.ParseInt("one thousand five hundred"));
		Assert.AreEqual(1555, ParseIntReloaded.ParseInt("one thousand five hundred and fifty-five"));
		Assert.AreEqual(500000, ParseIntReloaded.ParseInt("five hundred thousand"));
		Assert.AreEqual(100055, ParseIntReloaded.ParseInt("one hundred thousand and fifty-five"));
		Assert.AreEqual(100500, ParseIntReloaded.ParseInt("one hundred thousand five hundred"));
		Assert.AreEqual(100555, ParseIntReloaded.ParseInt("one hundred thousand five hundred and fifty-five"));
		
		Assert.AreEqual(155555, ParseIntReloaded.ParseInt("one hundred and fifty-five thousand five hundred and fifty-five"));
		
	}
}