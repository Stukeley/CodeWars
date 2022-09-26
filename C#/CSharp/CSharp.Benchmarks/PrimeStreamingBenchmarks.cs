namespace CSharp.Benchmarks;

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Code;

public class PrimeStreamingBenchmarks
{
	public static int Skip = 1000;
	public static int Take = 49_500_000;

	[Benchmark(Baseline = true)]
	public void StreamBenchmark()
	{
		var result = PrimeStreaming.Stream().Skip(Skip).Take(Take);
		
		Console.WriteLine($"{result.Count()} primes");
	}

	// [Benchmark]
	// public void StreamV2Benchmark()
	// {
	// 	var result = PrimeStreaming.StreamV2().Skip(Skip).Take(Take);
	// 	
	// 	Console.WriteLine(result.ToString());
	// }
	//
	// [Benchmark]
	// public void StreamV3Benchmark()
	// {
	// 	var result = PrimeStreaming.StreamV3().Skip(Skip).Take(Take);
	// 	
	// 	Console.WriteLine(result.ToString());
	// }
	//
	// [Benchmark]
	// public void StreamV4Benchmark()
	// {
	// 	var result = PrimeStreaming.StreamV4().Skip(Skip).Take(Take);
	// 	
	// 	Console.WriteLine(result.ToString());
	// }
}