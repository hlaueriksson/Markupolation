using System.Text;
using BenchmarkDotNet.Attributes;

namespace Markupolation.Benchmark;

/// <summary>
/// Nesting depth, rather than sibling count, is what makes an eagerly rendered tree expensive:
/// every level re-copies the whole subtree rendered beneath it.
/// </summary>
[MemoryDiagnoser]
public class DeepNesting
{
    private const int Depth = 20;

    private StringBuilder _builder = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
        _builder = new StringBuilder();
    }

    [Benchmark(Baseline = true)]
    public string StringBuilder()
    {
        _builder.Clear();
        _builder.Append("<html><body>");
        for (var i = 0; i < Depth; i++)
        {
            _builder.Append("<div class=\"level").Append(i).Append("\">");
        }

        _builder.Append("leaf");
        for (var i = 0; i < Depth; i++)
        {
            _builder.Append("</div>");
        }

        _builder.Append("</body></html>");
        return _builder.ToString();
    }

    [Benchmark]
#pragma warning disable CA1822 // Mark members as static
    public string Markupolation()
#pragma warning restore CA1822 // Mark members as static
    {
        Content content = "leaf";
        for (var i = Depth - 1; i >= 0; i--)
        {
            content = div(class_($"level{i}"), content);
        }

        return html(body(content)).ToString();
    }

    public static bool IsValid()
    {
        var benchmark = new DeepNesting();
        benchmark.GlobalSetup();
        return benchmark.Markupolation().IsEquivalentTo(benchmark.StringBuilder());
    }
}
