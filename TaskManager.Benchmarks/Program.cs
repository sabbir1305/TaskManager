using BenchmarkDotNet.Running;

namespace TaskManager.Benchmarks;

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<AssignmentStrategyBenchmarks>();
    }
}
