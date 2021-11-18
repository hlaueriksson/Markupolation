using System;
using BenchmarkDotNet.Running;

namespace Markupolation.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (!BasicUsage.IsValid()) throw new Exception("BasicUsage is not valid");
            if (!AdvancedUsage.IsValid()) throw new Exception("AdvancedUsage is not valid");

            BenchmarkRunner.Run<BasicUsage>();
            BenchmarkRunner.Run<AdvancedUsage>();
        }
    }
}
