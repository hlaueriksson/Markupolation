using BenchmarkDotNet.Attributes;

namespace Markupolation.Benchmark
{
    public class StringBenchmarks
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
        }

        [Benchmark]
        public string Html()
        {
            var numbers = new[] { 1, 2, 3 };
            return $"{DOCTYPE() + html(head(meta("charset='utf-8'"), Elements.title("Hej")), body(ul(numbers.Each(x => li(x.ToString(), title(x.ToString()))))))}";
        }
    }
}
