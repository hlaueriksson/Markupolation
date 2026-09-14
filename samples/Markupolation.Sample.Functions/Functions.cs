using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace Markupolation.Sample.Functions;

public class Functions
{
    [Function(nameof(Html))]
    public IActionResult Html([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req) => new ContentResult
    {
        ContentType = "text/html; charset=utf-8",
        Content =
            (DOCTYPE() +
            html(lang("en"),
                head(
                    meta(charset("utf-8")),
                    e.title("Markupolation.Sample.Functions"),
                    meta(name("description"), content("Sample of how to use Markupolation in an Azure Function")),
                    meta(name("viewport"), content("width=device-width, initial-scale=1"))
                ),
                body(onload("console.log('Markupolation in an Azure Function');"),
                    h1("Hello, World!"),
                    p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
                )
            )).ToString(),
    };

    [Function(nameof(Hello))]
    public IActionResult Hello([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req) => new ContentResult
    {
        ContentType = "text/html; charset=utf-8",
        Content = (h1("Hello, World!") + p("This is ", mark(title("Markup with string interpolation"), "Markupolation"), " in action.")).ToString(),
    };

    [Function(nameof(Counter))]
    public IActionResult Counter([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Counter/{count:int}")] HttpRequest req, int count)
    {
        var result = mark(a.title(count), Humanizer.NumberToWordsExtension.ToWords(count));

        return new ContentResult
        {
            ContentType = "text/html; charset=utf-8",
            Content = req.Headers["HX-Request"].Count > 0 ?
                (h1("Counter") +
                p(new A("role", "status"), $"Current count: {result}") +
                button(
                    class_("btn btn-primary"),
                    hx_get($"/api/counter/{count + 1}"),
                    hx_target("#result"),
                    "Click me"
                )).ToString() :
                result.ToString(),
        };
    }

    static readonly string[] summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    static readonly Func<WeatherForecast[]> forecasts = () =>
        [.. Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            )
        )];

    [Function(nameof(Weather))]
    public IActionResult Weather([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req) => new ContentResult
    {
        ContentType = "text/html; charset=utf-8",
        Content =
            $$"""
            <table class="table">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {{forecasts().Each(x => tr(
                        td(x.Date.ToShortDateString()),
                        td(x.TemperatureC),
                        td(x.TemperatureF),
                        td(x.Summary)
                    ))}}
                </tbody>
            </table>
            """,
    };

    record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
