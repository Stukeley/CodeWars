namespace CSharp.Tests;

using Code;
using NUnit.Framework;

[TestFixture]
public class SumOfPerfectSquaresTests
{
	[Test]
	public void IsFirstImplementationCorrect()
	{
		const int n = 120340;
		const int expected = 7;

		Assert.AreEqual(expected, SumOfSquares.NSquaresFor(n));
	}

	[Test]
	public void AreEasyCasesCorrect()
	{
		Assert.AreEqual(4, SumOfSquares.NSquaresFor(15));
		Assert.AreEqual(1, SumOfSquares.NSquaresFor(16));
		Assert.AreEqual(2, SumOfSquares.NSquaresFor(17));
		Assert.AreEqual(2, SumOfSquares.NSquaresFor(18));
		Assert.AreEqual(3, SumOfSquares.NSquaresFor(19));
	}

	[Test]
	public void TestOriginal()
	{
		Assert.AreEqual(3, SumOfSquares.NSquaresFor(524199765));
		Assert.AreEqual(4, SumOfSquares.NSquaresFor(661915703));
		Assert.AreEqual(4, SumOfSquares.NSquaresFor(2017));
		Assert.AreEqual(4, SumOfSquares.NSquaresFor(1008));
	}
}