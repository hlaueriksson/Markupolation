using BenchmarkDotNet.Running;

namespace Markupolation.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringBenchmarks>();
        }
    }
}
