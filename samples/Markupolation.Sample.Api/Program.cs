var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Extensions.Html(
    DOCTYPE() +
    html(lang("en"),
        head(
            meta(charset("utf-8")),
            e.title("Markupolation.Sample.Api"),
            meta(name("description"), content("Sample of how to use Markupolation in a net6.0 Web Api")),
            meta(name("viewport"), content("width=device-width, initial-scale=1"))
        ),
        body(onload("console.log('Markupolation in a net6.0 Web Api');"),
            h1("Hello, World!"),
            p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
        )
    )
));

app.MapGet("/hello", () => Results.Extensions.Html(
    h1("Hello, World!") + p("This is ", mark(title("Markup with string interpolation"), "Markupolation"), " in action.")
));

app.MapGet("/counter/{count:int}", (int count) => Results.Extensions.Html(
    mark(a.title(count), Humanizer.NumberToWordsExtension.ToWords(count))
));

app.MapGet("/weather", () =>
{
    var forecasts = new[]
    {
        new { Date = DateTime.Parse("2018-05-06"), TemperatureC = 1, Summary = "Freezing" },
        new { Date = DateTime.Parse("2018-05-07"), TemperatureC = 14, Summary = "Bracing" },
        new { Date = DateTime.Parse("2018-05-08"), TemperatureC = -13, Summary = "Freezing" },
        new { Date = DateTime.Parse("2018-05-09"), TemperatureC = -16, Summary = "Balmy" },
        new { Date = DateTime.Parse("2018-05-10"), TemperatureC = -2, Summary = "Chilly" },
    };

    return Results.Extensions.Html($$"""
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
                {{forecasts.Each(x => tr(
                    td(x.Date.ToShortDateString()),
                    td(x.TemperatureC),
                    td(TemperatureF(x)),
                    td(x.Summary)
                ))}}
            </tbody>
        </table>
    """);

    static int TemperatureF(dynamic forecast) => 32 + (int)(forecast.TemperatureC / 0.5556);
});

app.Run();
