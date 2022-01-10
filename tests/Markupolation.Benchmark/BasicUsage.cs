using System.Text;
using BenchmarkDotNet.Attributes;
using HtmlTags;

namespace Markupolation.Benchmark
{
    public class BasicUsage
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private StringBuilder _builder;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [GlobalSetup]
        public void GlobalSetup()
        {
            _builder = new StringBuilder();
        }

        [Benchmark]
        public string StringBuilder()
        {
            _builder.Clear();
            _builder.Append("<!DOCTYPE html><html><head><title>");
            _builder.Append("Markupolation");
            _builder.Append("</title></head><body><h1>");
            _builder.Append("Hello, World!");
            _builder.Append("</h1></body></html>");
            return _builder.ToString();
        }

        [Benchmark]
        public string StringFormat()
        {
            return string.Format("<!DOCTYPE html><html><head><title>{0}</title></head><body><h1>{1}</h1></body></html>", "Markupolation", "Hello, World!");
        }

        [Benchmark]
        public string Markupolation()
        {
            return $"{DOCTYPE() + html(head(e.title("Markupolation")), body(h1("Hello, World!")))}";
        }

        [Benchmark]
        public string HtmlTags()
        {
            var doc = new HtmlDocument();
            doc.Title = "Markupolation";
            doc.Add("h1").Text("Hello, World!");
            return doc.ToString();
        }

        public static bool IsValid()
        {
            var benchmark = new BasicUsage();
            benchmark.GlobalSetup();
            return
                benchmark.Markupolation() == benchmark.StringBuilder() &&
                benchmark.Markupolation() == benchmark.StringFormat() &&
                benchmark.Markupolation() == benchmark.HtmlTags().ReplaceLineEndings(string.Empty);
        }
    }
}
