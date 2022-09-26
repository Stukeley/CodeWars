namespace CSharp.Tests;

using System.Collections.Generic;
using Code;
using NUnit.Framework;

[TestFixture]
public class CatchingCarMileageNumbersTests
{
	[Test]
	public void AdvancedTest()
	{
		Assert.AreEqual(2, CatchingCarMileageNumbers.IsInteresting(3210, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(7382, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(24866, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(81594, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(36725, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(84483, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(90564, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(42807, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(99534, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(18785, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(4019, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(8504, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(65232, new List<int>() {  }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(17474, new List<int>() {  }));
	}
	
	[Test]
	public void ShouldWorkTest()
	{
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(3, new List<int>() { 1337, 256 }));
		Assert.AreEqual(1, CatchingCarMileageNumbers.IsInteresting(1336, new List<int>() { 1337, 256 }));
		Assert.AreEqual(2, CatchingCarMileageNumbers.IsInteresting(1337, new List<int>() { 1337, 256 }));
		Assert.AreEqual(0, CatchingCarMileageNumbers.IsInteresting(11208, new List<int>() { 1337, 256 }));
		Assert.AreEqual(1, CatchingCarMileageNumbers.IsInteresting(11209, new List<int>() { 1337, 256 }));
		Assert.AreEqual(2, CatchingCarMileageNumbers.IsInteresting(11211, new List<int>() { 1337, 256 }));
	}
}