var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddPolicy("AnyOrigin", o => o.AllowAnyOrigin()));

var app = builder.Build();
app.UseCors();

app.MapGet("/", () => Results.Extensions.Html(
    $@"{DOCTYPE() +
    html(lang("en"),
        head(
            meta(charset("utf-8")),
            e.title("Markupolation.Sample.Api"),
            meta(name("description"), content("Sample of how to use Markupolation in a net6.0 Web Api")),
            meta(name("viewport"), content("width=device-width, initial-scale=1"))
        ),
        body(
            h1("Hello, World!"),
            p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
        )
    )}"
));

app.MapGet("/hello", () => Results.Extensions.Html(
    $"{h1("Hello, World!") + p("This is ", mark(title("Markup with string interpolation"), "Markupolation"), " in action.")}"
)).RequireCors("AnyOrigin");

app.MapGet("/counter/{count:int}", (int count) => Results.Extensions.Html(
    $"{mark(title(count.ToString()), Humanizer.NumberToWordsExtension.ToWords(count))}"
)).RequireCors("AnyOrigin");

app.Run();
