using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Diffing;
using FluentAssertions;
using NUnit.Framework;

namespace Markupolation.Tests;

[Explicit]
public class PlaygroundTests
{
    [Test]
    public async Task html5_boilerplate()
    {
        var actual =
            DOCTYPE() +
            html(lang(""),
                head(
                    meta(charset("utf-8")),
                    meta(name("viewport"), content("width=device-width, initial-scale=1")),
                    Elements.title(""),
                    link(rel("stylesheet"), href("css/style.css")),
                    meta(name("description"), content("")),

                    meta(new Attribute("property", "og:title"), content("")),
                    meta(new Attribute("property", "og:type"), content("")),
                    meta(new Attribute("property", "og:url"), content("")),
                    meta(new Attribute("property", "og:image"), content("")),
                    meta(new Attribute("property", "og:image:alt"), content("")),

                    link(rel("icon"), href("/favicon.ico"), sizes("any")),
                    link(rel("icon"), href("/icon.svg"), type("image/svg+xml")),
                    link(rel("apple-touch-icon"), href("icon.png")),

                    link(rel("manifest"), href("site.webmanifest")),
                    meta(name("theme-color"), content("#fafafa"))
                ),
                body(

                    // A comment is markup, not text, so it has to say so under escape-by-default.
                    comment(" Add your site or application content here "),
                    p("Hello world! This is HTML5 Boilerplate."),
                    script(src("js/app.js"))
                )
            );

        using var client = new HttpClient();
        var expected = await client.GetStringAsync("https://raw.githubusercontent.com/h5bp/html5-boilerplate/main/src/index.html");

        var diffs = DiffBuilder.Compare(expected).WithTest(actual.ToString()).Build().ToList();
        diffs.Should().BeEmpty();
    }
}
