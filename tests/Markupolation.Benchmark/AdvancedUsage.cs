using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Markupolation.Benchmark
{
    public class AdvancedUsage
    {
        readonly Func<int, bool> fizz = (int i) => i % 3 == 0;
        readonly Func<int, bool> buzz = (int i) => i % 5 == 0;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private IEnumerable<int> _numbers;
        private StringBuilder _builder;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [GlobalSetup]
        public void GlobalSetup()
        {
            _numbers = Enumerable.Range(1, 100);
            _builder = new StringBuilder();
        }

        [Benchmark]
        public string StringBuilder()
        {
            _builder.Clear();
            _builder.Append("<!DOCTYPE html><html lang=\"en\"><head><meta charset=\"utf-8\" /><title>Markupolation.Extensions</title><meta name=\"description\" content=\"Sample of how to use Markupolation.Extensions\" /><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" /></head><body><ul>");
            foreach (int i in _numbers)
            {
                _builder.Append("<li>");
                if (fizz(i) && buzz(i))
                {
                    _builder.Append("<strong>");
                    _builder.Append("FizzBuzz");
                    _builder.Append("</strong>");
                }
                else if (fizz(i))
                {
                    _builder.Append("<em>");
                    _builder.Append("Fizz");
                    _builder.Append("</em>");
                }
                else if (buzz(i))
                {
                    _builder.Append("<em>");
                    _builder.Append("Buzz");
                    _builder.Append("</em>");
                }
                else
                {
                    _builder.Append(i);
                }
                _builder.Append("</li>");
            }
            _builder.Append("</ul></body></html>");
            return _builder.ToString();
        }

        [Benchmark]
        public string StringFormat()
        {
            var result = "<!DOCTYPE html><html lang=\"en\"><head><meta charset=\"utf-8\" /><title>Markupolation.Extensions</title><meta name=\"description\" content=\"Sample of how to use Markupolation.Extensions\" /><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" /></head><body><ul>";
            foreach (int i in _numbers)
            {
                result += "<li>";
                if (fizz(i) && buzz(i))
                {
                    result += string.Format("<strong>{0}</strong>", "FizzBuzz");
                }
                else if (fizz(i))
                {
                    result += string.Format("<em>{0}</em>", "Fizz");
                }
                else if (buzz(i))
                {
                    result += string.Format("<em>{0}</em>", "Buzz");
                }
                else
                {
                    result += i;
                }
                result += "</li>";
            }
            result += "</ul></body></html>";
            return result;
        }

        [Benchmark]
        public string Markupolation()
        {
            return $@"{DOCTYPE() +
            html(lang("en"),
                head(
                    meta(charset("utf-8")),
                    e.title("Markupolation.Extensions"),
                    meta(name("description"), content("Sample of how to use Markupolation.Extensions")),
                    meta(name("viewport"), content("width=device-width, initial-scale=1"))
                ),
                body(
                    ul(
                        _numbers.Each(x => li(
                            x.IfMatch(i => fizz(i) && buzz(i), i => strong("FizzBuzz")),
                            x.IfMatch(i => fizz(i) && !buzz(i), i => em("Fizz")),
                            x.IfMatch(i => !fizz(i) && buzz(i), i => em("Buzz")),
                            x.IfMatch(i => !fizz(i) && !buzz(i), i => i.ToString())
                        ))
                    )
                )
            )}";
        }

        public static bool IsValid()
        {
            var benchmark = new AdvancedUsage();
            benchmark.GlobalSetup();
            return benchmark.Markupolation() == benchmark.StringBuilder() && benchmark.Markupolation() == benchmark.StringFormat();
        }
    }
}
