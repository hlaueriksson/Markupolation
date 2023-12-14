using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Diffing;
using BenchmarkDotNet.Running;

namespace Markupolation.Benchmark
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (!await BasicUsage.IsValid()) throw new Exception("BasicUsage is not valid");
            if (!await AdvancedUsage.IsValid()) throw new Exception("AdvancedUsage is not valid");

            BenchmarkRunner.Run<BasicUsage>();
            BenchmarkRunner.Run<AdvancedUsage>();
        }
    }

    public static class HtmlExtensions
    {
        public static bool IsEquivalentTo(this string expected, string actual)
        {
            return !DiffBuilder.Compare(expected).WithTest(actual).Build().Any();
        }
    }
}
