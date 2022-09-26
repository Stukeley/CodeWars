namespace CSharp.Tests;

using Code;
using NUnit.Framework;

[TestFixture]
public class DirectionReductionTests
{
	[Test]
	public void SampleTest1()
	{
		string[] a = new string[] {"NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"};
		string[] b = new string[] {"WEST"};
		Assert.AreEqual(b, DirectionsReduction.dirReduc(a));
	}

	[Test]
	public void SampleTest2()
	{
		string[] a = new string[] {"NORTH", "WEST", "SOUTH", "EAST"};
		string[] b = new string[] {"NORTH", "WEST", "SOUTH", "EAST"};
		Assert.AreEqual(b, DirectionsReduction.dirReduc(a));
	}
}