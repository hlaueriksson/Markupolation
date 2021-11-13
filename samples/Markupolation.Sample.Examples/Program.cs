using Markupolation;
using static Markupolation.Elements;
using static Markupolation.Attributes;
using e = Markupolation.Elements;
using a = Markupolation.Attributes;

var result = $"{DOCTYPE() + html(head(e.title("Markupolation")), body(h1("Hello, World!")))}";
Console.WriteLine(result);

var links = new[] { new { Url = "#", Title = "Foo", Active = true }, new { Url = "#", Title = "Bar", Active = false } };
result = links.Each((x, index) => a(href(x.Url), id($"link{index}"), x.IfMatch(x => x.Active, x => class_("active")), x.Title));
Console.WriteLine(result);

result = $@"{DOCTYPE() +
html(lang("en"),
    head(
        meta(charset("utf-8")),
        e.title("Markupolation"),
        meta(name("description"), content("Sample of how to use Markupolation")),
        meta(name("viewport"), content("width=device-width, initial-scale=1"))
    ),
    body(
        h1("Hello, World!"),
        p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
    )
)}";
Console.WriteLine(result);

string foo = "foo";
string bar = null;
result = $@"{DOCTYPE() +
html(
    body(
        foo.IfNotNull(x => div(x)),
        bar.IfNull(div("bar is null"))
    )
)}";
Console.WriteLine(result);

Func<int, bool> fizz = (int i) => i % 3 == 0;
Func<int, bool> buzz = (int i) => i % 5 == 0;
var numbers = Enumerable.Range(1, 15);
result = $@"{DOCTYPE() +
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
                x.IfMatch(i => fizz(i) && buzz(i), i => strong("FizzBuzz")),
                x.IfMatch(i => fizz(i) && !buzz(i), i => em("Fizz")),
                x.IfMatch(i => !fizz(i) && buzz(i), i => em("Buzz")),
                x.IfMatch(i => !fizz(i) && !buzz(i), i => i.ToString())
            ))
        )
    )
)}";
Console.WriteLine(result);
