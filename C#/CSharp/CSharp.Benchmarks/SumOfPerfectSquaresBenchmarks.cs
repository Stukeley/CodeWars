namespace CSharp.Benchmarks;

using BenchmarkDotNet.Attributes;
using Code;

public class SumOfPerfectSquaresBenchmarks
{
	private const int N = 12000340;
	
	[Benchmark(Baseline = true)]
	public void SumOfPerfectSquares_v1()
	{
		int n = SumOfSquares.NSquaresFor(N);
	}
}