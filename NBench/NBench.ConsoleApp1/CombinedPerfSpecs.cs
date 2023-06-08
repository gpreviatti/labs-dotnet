
using NBench.Util;

namespace NBench.ConsoleApp1;

/// <summary>
/// Test to see gauge the impact of having multiple things to measure on a benchmark
/// </summary>
public class CombinedPerfSpecs : IDisposable
{
    private Counter? _counter;

    [PerfSetup]
    public void Setup(BenchmarkContext context)
    {
        _counter = context.GetCounter("TestCounter");
    }

    [PerfBenchmark(
        Description = "Test to gauge the impact of having multiple things to measure on a benchmark.", 
        NumberOfIterations = 10, 
        RunMode = RunMode.Throughput, 
        RunTimeMilliseconds = 1000, 
        TestMode = TestMode.Test
    )]
    [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
    [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThanOrEqualTo, ByteConstants.ThirtyTwoKb)]
    [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.ExactlyEqualTo, 0.0d)]
    public void Benchmark()
    {
        var sum = 0;
        for (int i = 0; i < 100; i++)
            sum = 10 * sum;

        _counter!.Increment();
    }

    public void Dispose()
    {
    }
}
