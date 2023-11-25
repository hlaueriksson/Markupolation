using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

var app = builder.Build();
app.MapDefaultEndpoints();

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

app.MapGet("/counter/{count:int?}", ([FromRoute(Name = "count")] int? routeCount, [FromQuery(Name = "count")] int? queryCount) =>
{
    int count = routeCount ?? queryCount ?? 0;

    return Results.Extensions.Html(
        mark(a.title(count), Humanizer.NumberToWordsExtension.ToWords(count))
    );
});

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weather", () =>
{
    var forecasts = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

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
                    td(x.TemperatureF),
                    td(x.Summary)
                ))}}
            </tbody>
        </table>
    """);
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
