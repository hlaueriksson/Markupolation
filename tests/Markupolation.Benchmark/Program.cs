using System;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Diffing;
using BenchmarkDotNet.Running;

namespace Markupolation.Benchmark;

public class Program
{
    public static async Task Main(string[] args)
    {
        if (!await BasicUsage.IsValid()) throw new Exception("BasicUsage is not valid");
        if (!await AdvancedUsage.IsValid()) throw new Exception("AdvancedUsage is not valid");
        if (!DeepNesting.IsValid()) throw new Exception("DeepNesting is not valid");

        BenchmarkRunner.Run<BasicUsage>(null, args);
        BenchmarkRunner.Run<AdvancedUsage>(null, args);
        BenchmarkRunner.Run<DeepNesting>(null, args);
    }
}

public static class HtmlExtensions
{
    public static bool IsEquivalentTo(this string expected, string actual)
    {
        return !DiffBuilder.Compare(expected).WithTest(actual).Build().Any();
    }
}
