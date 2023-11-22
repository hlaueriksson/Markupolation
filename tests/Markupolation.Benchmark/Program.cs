using System;
using System.Linq;
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

    public static class StringExtensions
    {
        public static string Minify(this string html)
        {
            return string.Join(string.Empty, html.Split(["\n", Environment.NewLine], StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()));
        }
    }
}
