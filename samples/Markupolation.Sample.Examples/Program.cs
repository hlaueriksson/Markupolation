using Microsoft.Playwright;
using Spectre.Console;

AnsiConsole.MarkupLine("Examples of [blue]Markupolation[/] {0} in action together with [green]Playwright[/] :performing_arts:", Markup.Escape("<:scroll:>"));
AnsiConsole.MarkupLine(string.Empty);
AnsiConsole.MarkupLine("Prerequisites:");
AnsiConsole.MarkupLine("1. Install Playwright:");
AnsiConsole.MarkupLine("   - Open a PowerShell terminal and run:");
AnsiConsole.MarkupLine("   - [lime].\\bin\\Debug\\net8.0\\playwright.ps1 install[/]");
AnsiConsole.MarkupLine(string.Empty);
AnsiConsole.MarkupLine("Instructions:");
AnsiConsole.MarkupLine("- Use [blue]Up[/]⬆️ and [blue]Down[/]⬇️ keys to scroll through examples");
AnsiConsole.MarkupLine("- Press [blue]Enter[/]↩️ to select an example");
AnsiConsole.MarkupLine("- Exit with [blue]Ctrl+C[/] or select the [blue]Exit[/] example");
AnsiConsole.MarkupLine(string.Empty);

var links = new[]
{
    new Link("https://github.com/hlaueriksson/Markupolation", "The repo for this sample project.", true),
    new Link("https://github.com/microsoft/playwright-dotnet", "Playwright enables reliable end-to-end testing for modern web apps.", false),
    new Link("https://github.com/spectreconsole/spectre.console", "Spectre.Console is a .NET library that makes it easier to create beautiful console applications.", false),
    null, // This link is broken
};

using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });

while (true)
{
    var example = AnsiConsole.Prompt(
        new SelectionPrompt<Example>()
            .Title("What kind of example would you like to see?")
            .AddChoices(Enum.GetValues<Example>()));

    if (example == Example.Exit) break;

    AnsiConsole.MarkupLine($"Opening a [green]Playwright[/] browser with the [blue]{example}[/] example[gray]...[/]");
    AnsiConsole.MarkupLine(string.Empty);

    var result = GetHtml(example);

    var page = await browser.NewPageAsync();
    await page.SetContentAsync(result);
}

var root = new Tree("Links:")
    .Guide(TreeGuide.Line)
    .Style("gray");
foreach (var link in links)
{
    if (link is null) continue;
    root.AddNode($"[blue][link={link.Url}]{link.Url}[/][/]")
        .AddNode(link.Title);
}
AnsiConsole.Write(root);

string GetHtml(Example example) => example switch
{
    Example.Simple => Simple(),
    Example.Elaborate => Elaborate(),
    Example.FizzBuzz => FizzBuzz(),
    _ => string.Empty,
};

string Simple() => DOCTYPE() + html(head(e.title("Markupolation")), body(h1("Hello, World!")));

string Elaborate() =>
    $"""
    {DOCTYPE() +
    html(lang("en"),
        head(
            meta(charset("utf-8")),
            e.title("Markupolation"),
            meta(name("description"), content("Sample of how to use Markupolation")),
            meta(name("viewport"), content("width=device-width, initial-scale=1"))
        ),
        body(
            h1("Hello, World!"),
            p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action."),
            table(
                tr(
                    th("Link"), th("Description")
                ),
                links.Each((x, index) =>
                    x.IfNotNull(x =>
                        tr(td(a(href(x!.Url), id($"link{index}"), x.IfMatch(x => x.Active, x => class_("active")), x.Url), td(x.Title))),
                        tr(td(u("null")), td(i("(broken link)")))
                    )
                )
            )
        )
    )}
    """;

string FizzBuzz()
{
    bool Fizz(int i) => i % 3 == 0;
    bool Buzz(int i) => i % 5 == 0;
    var numbers = Enumerable.Range(1, 15);
    return $"{
        DOCTYPE() +
        html(lang("en"),
            head(
                meta(charset("utf-8")),
                e.title("Markupolation.Extensions"),
                meta(name("description"), content("Sample of how to use Markupolation.Extensions")),
                meta(name("viewport"), content("width=device-width, initial-scale=1"))
            ),
            body(
                ul(
                    numbers.Each(x => li(
                        x.IfMatch(i => Fizz(i) && Buzz(i), i => strong("FizzBuzz")),
                        x.IfMatch(i => Fizz(i) && !Buzz(i), i => em("Fizz")),
                        x.IfMatch(i => !Fizz(i) && Buzz(i), i => em("Buzz")),
                        x.IfMatch(i => !Fizz(i) && !Buzz(i), i => i.ToString())
                    ))
                )
            )
        )}";
}

enum Example
{
    Simple,
    Elaborate,
    FizzBuzz,
    Exit,
}

record Link(string Url, string Title, bool Active);
