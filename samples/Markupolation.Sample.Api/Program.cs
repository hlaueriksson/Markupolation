var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddProblemDetails();
builder.AddServiceDefaults();

var app = builder.Build();
app.UseCors();
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapDefaultEndpoints();

app.MapGet("/", () => Results.Text(contentType: "text/html; charset=utf-8", content:
    DOCTYPE() +
    html(lang("en"),
        head(
            meta(charset("utf-8")),
            e.title("Markupolation.Sample.Api"),
            meta(name("description"), content("Sample of how to use Markupolation in a Minimal API")),
            meta(name("viewport"), content("width=device-width, initial-scale=1"))
        ),
        body(onload("console.log('Markupolation in a Minimal API');"),
            h1("Hello, World!"),
            p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
        )
    )
));

app.MapGet("/hello", () => Results.Text(contentType: "text/html; charset=utf-8", content:
    h1("Hello, World!") + p("This is ", mark(title("Markup with string interpolation"), "Markupolation"), " in action.")
));

app.MapGet("/counter/{count}", (HttpRequest request, int count) =>
{
    var result = mark(a.title(count), Humanizer.NumberToWordsExtension.ToWords(count));

    return Results.Text(contentType: "text/html; charset=utf-8", content: request.Headers.ContainsKey("HX-Request") ?
        h1("Counter") +
        p(new A("role", "status"), $"Current count: {result}") +
        button(
            class_("btn btn-primary"),
            new A("hx-get", $"/api/counter/{count + 1}"),
            new A("hx-target", "#result"),
            "Click me"
        ) :
        result
    );
});

string[] summaries =
[
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
];

Func<WeatherForecast[]> forecasts = () =>
    Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        )
    )
    .ToArray();

app.MapGet("/weather", () => Results.Text(contentType: "text/html; charset=utf-8", content:
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
    """
));

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
