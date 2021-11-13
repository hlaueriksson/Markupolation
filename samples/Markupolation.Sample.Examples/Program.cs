using Markupolation;
using e = Markupolation.Elements;
using static Markupolation.Elements;
using a = Markupolation.Attributes;
using static Markupolation.Attributes;

var result = $"{DOCTYPE() + html(head(e.title("Markupolation")), body(h1("Hello, World!")))}";
Console.WriteLine(result);

var links = new[] { new { Url = "#", Title = "Foo", Active = true }, new { Url = "#", Title = "Bar", Active = false } };
result = links.Each((x, index) => a(href(x.Url), id($"link{index}"), x.IfMatch(x => x.Active, x => class_("active")), x.Title));
Console.WriteLine(result);

result = $@"{DOCTYPE() +
html(lang("en"),
    head(
        meta(charset("utf-8")),
        e.title("Markupolation.Sample.Api"),
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

var numbers = Enumerable.Range(0, 10);
result = $@"{DOCTYPE() +
html(
    body(
        numbers.Each(x => div(class_(x % 2 == 0 ? "even" : "odd"), x.ToString()))
    )
)}";
Console.WriteLine(result);
