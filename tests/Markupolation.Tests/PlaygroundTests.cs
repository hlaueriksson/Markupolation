using System;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Diffing;
using FluentAssertions;
using Humanizer;
using Markdig;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Markupolation.Tests
{
    [Explicit]
    public class PlaygroundTests
    {
        [Test]
        public async Task html5_boilerplate()
        {
            var actual =
$@"{DOCTYPE() +
html(class_("no-js"), lang(""),
    head(
        meta(charset("utf-8")),
        Elements.title(""),
        meta(name("description"), content("")),
        meta(name("viewport"), content("width=device-width, initial-scale=1")),

        meta(new Attribute("property", "og:title"), content("")),
        meta(new Attribute("property", "og:type"), content("")),
        meta(new Attribute("property", "og:url"), content("")),
        meta(new Attribute("property", "og:image"), content("")),

        link(rel("manifest"), href("site.webmanifest")),
        link(rel("apple-touch-icon"), href("icon.png")),
        "<!-- Place favicon.ico in the root directory -->",

        link(rel("stylesheet"), href("css/normalize.css")),
        link(rel("stylesheet"), href("css/style.css")),

        meta(name("theme-color"), content("#fafafa"))
    ),
    body(

        "<!-- Add your site or application content here -->",
        p("Hello world! This is HTML5 Boilerplate."),
        script(src("js/vendor/modernizr-{{MODERNIZR_VERSION}}.min.js")),
        script(src("js/app.js")),

        "<!-- Google Analytics: change UA-XXXXX-Y to be your site's ID. -->",
        script(
@"
    window.ga = function () { ga.q.push(arguments) }; ga.q = []; ga.l = +new Date;
    ga('create', 'UA-XXXXX-Y', 'auto'); ga('set', 'anonymizeIp', true); ga('set', 'transport', 'beacon'); ga('send', 'pageview')
  "),
        script(src("https://www.google-analytics.com/analytics.js"), async())
    )
)}";

            using var client = new HttpClient();
            var expected = await client.GetStringAsync("https://raw.githubusercontent.com/h5bp/html5-boilerplate/main/src/index.html");

            var diffs = DiffBuilder
                .Compare(expected)
                .WithTest(actual)
                .Build()
                .ToList();

            diffs.Should().BeEmpty();
        }

        [Test]
        public async Task bootstrap_starter_template()
        {
            var actual =
$@"{DOCTYPE() +
html(lang("en"),
    head(
        meta(charset("utf-8")),
        meta(name("viewport"), content("width=device-width, initial-scale=1")),
        meta(name("description"), content("")),
        meta(name("author"), content("Mark Otto, Jacob Thornton, and Bootstrap contributors")),
        meta(name("generator"), content("Hugo 0.88.1")),
        Elements.title("Starter Template · Bootstrap v5.1"),

        link(rel("canonical"), href("https://getbootstrap.com/docs/5.1/examples/starter-template/")),

        "<!-- Bootstrap core CSS -->",
        link(href("/docs/5.1/dist/css/bootstrap.min.css"), rel("stylesheet"), integrity("sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3"), crossorigin("anonymous")),

        "<!-- Favicons -->",
        link(rel("apple-touch-icon"), href("/docs/5.1/assets/img/favicons/apple-touch-icon.png"), sizes("180x180")),
        link(rel("icon"), href("/docs/5.1/assets/img/favicons/favicon-32x32.png"), sizes("32x32"), type("image/png")),
        link(rel("icon"), href("/docs/5.1/assets/img/favicons/favicon-16x16.png"), sizes("16x16"), type("image/png")),
        link(rel("manifest"), href("/docs/5.1/assets/img/favicons/manifest.json")),
        link(rel("mask-icon"), href("/docs/5.1/assets/img/favicons/safari-pinned-tab.svg"), color("#7952b3")),
        link(rel("icon"), href("/docs/5.1/assets/img/favicons/favicon.ico")),
        meta(name("theme-color"), content("#7952b3")),

        Elements.style(
@"
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
"
        ),

        "<!-- Custom styles for this template -->",
        link(href("starter-template.css"), rel("stylesheet"))
    ),
    body(
        div(class_("col-lg-8 mx-auto p-3 py-md-5"),
            header(class_("d-flex align-items-center pb-3 mb-5 border-bottom"),
                a(href("/"), class_("d-flex align-items-center text-dark text-decoration-none"),
                    new Element("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"40\" height=\"32\" class=\"me-2\" viewBox=\"0 0 118 94\" role=\"img\"><title>Bootstrap</title><path fill-rule=\"evenodd\" clip-rule=\"evenodd\" d=\"M24.509 0c-6.733 0-11.715 5.893-11.492 12.284.214 6.14-.064 14.092-2.066 20.577C8.943 39.365 5.547 43.485 0 44.014v5.972c5.547.529 8.943 4.649 10.951 11.153 2.002 6.485 2.28 14.437 2.066 20.577C12.794 88.106 17.776 94 24.51 94H93.5c6.733 0 11.714-5.893 11.491-12.284-.214-6.14.064-14.092 2.066-20.577 2.009-6.504 5.396-10.624 10.943-11.153v-5.972c-5.547-.529-8.934-4.649-10.943-11.153-2.002-6.484-2.28-14.437-2.066-20.577C105.214 5.894 100.233 0 93.5 0H24.508zM80 57.863C80 66.663 73.436 72 62.543 72H44a2 2 0 01-2-2V24a2 2 0 012-2h18.437c9.083 0 15.044 4.92 15.044 12.474 0 5.302-4.01 10.049-9.119 10.88v.277C75.317 46.394 80 51.21 80 57.863zM60.521 28.34H49.948v14.934h8.905c6.884 0 10.68-2.772 10.68-7.727 0-4.643-3.264-7.207-9.012-7.207zM49.948 49.2v16.458H60.91c7.167 0 10.964-2.876 10.964-8.281 0-5.406-3.903-8.178-11.425-8.178H49.948z\" fill=\"currentColor\"></path></svg>"),
                    span(class_("fs-4"), "Starter template")
                )
            ),
            main(
                h1("Get started with Bootstrap"),
                p(class_("fs-5 col-md-8"), "Quickly and easily get started with Bootstrap's compiled, production-ready files with this barebones example featuring some basic HTML and helpful links. Download all our examples to get started."),

                div(class_("mb-5"),
                    a(href("/docs/5.1/examples/"), class_("btn btn-primary btn-lg px-4"), "Download examples")
                ),

                hr(class_("col-3 col-md-2 mb-5")),

                div(class_("row g-5"),
                    div(class_("col-md-6"),
                        h2("Starter projects"),
                        p("Ready to beyond the starter template? Check out these open source projects that you can quickly duplicate to a new GitHub repository."),
                        ul(class_("icon-list"),
                            li(a(href("https://github.com/twbs/bootstrap-npm-starter"), rel("noopener"), target("_blank"), "Bootstrap npm starter")),
                            li(class_("text-muted"), "Bootstrap Parcel starter (coming soon!)")
                        )
                    ),
                    div(class_("col-md-6"),
                        h2("Guides"),
                        p("Read more detailed instructions and documentation on using or contributing to Bootstrap."),
                        ul(class_("icon-list"),
                            li(a(href("/docs/5.1/getting-started/introduction/"), "Bootstrap quick start guide")),
                            li(a(href("/docs/5.1/getting-started/webpack/"), "Bootstrap Webpack guide")),
                            li(a(href("/docs/5.1/getting-started/parcel/"), "Bootstrap Parcel guide")),
                            li(a(href("/docs/5.1/getting-started/contribute/"), "Contributing to Bootstrap"))
                        )
                    )
                )
            ),
            footer(class_("pt-5 my-5 text-muted border-top"),
                "Created by the Bootstrap team &middot; &copy; 2021"
            )
        ),
        script(src("/docs/5.1/dist/js/bootstrap.bundle.min.js"), integrity("sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p"), crossorigin("anonymous"))
    )
)}";

            using var client = new HttpClient();
            var expected = await client.GetStringAsync("https://getbootstrap.com/docs/5.1/examples/starter-template/");

            var diffs = DiffBuilder
                .Compare(expected)
                .WithTest(actual)
                .Build()
                .ToList();

            diffs.Should().BeEmpty();
        }

        [Test]
        public async Task tailwind_play()
        {
            var actual =
$@"<!DOCTYPE html><html><head>
                    <meta charset=""utf-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                    <style id=""_style"">/*! tailwindcss v2.2.7 | MIT License | https://tailwindcss.com*/

/*! modern-normalize v1.1.0 | MIT License | https://github.com/sindresorhus/modern-normalize */html{{-moz-tab-size:4;-o-tab-size:4;tab-size:4;line-height:1.15;-webkit-text-size-adjust:100%}}body{{margin:0;font-family:system-ui,-apple-system,Segoe UI,Roboto,Helvetica,Arial,sans-serif,Apple Color Emoji,Segoe UI Emoji}}code{{font-family:ui-monospace,SFMono-Regular,Consolas,Liberation Mono,Menlo,monospace;font-size:1em}}p,ul{{margin:0}}ul{{list-style:none;padding:0}}html{{font-family:ui-sans-serif,system-ui,-apple-system,BlinkMacSystemFont,Segoe UI,Roboto,Helvetica Neue,Arial,Noto Sans,sans-serif,Apple Color Emoji,Segoe UI Emoji,Segoe UI Symbol,Noto Color Emoji;line-height:1.5}}body{{font-family:inherit;line-height:inherit}}*,:after,:before{{box-sizing:border-box;border:0 solid}}img{{border-style:solid}}a{{color:inherit;text-decoration:inherit}}code{{font-family:ui-monospace,SFMono-Regular,Menlo,Monaco,Consolas,Liberation Mono,Courier New,monospace}}img,svg{{display:block;vertical-align:middle}}img{{max-width:100%;height:auto}}*,:after,:before{{--tw-border-opacity:1;border-color:rgba(229,231,235,var(--tw-border-opacity))}}.absolute{{position:absolute}}.relative{{position:relative}}.inset-0{{top:0;right:0;bottom:0;left:0}}.mx-auto{{margin-left:auto;margin-right:auto}}.ml-2{{margin-left:.5rem}}.flex{{display:flex}}.h-5{{height:1.25rem}}.h-6{{height:1.5rem}}.h-7{{height:1.75rem}}.min-h-screen{{min-height:100vh}}.w-5{{width:1.25rem}}.max-w-md{{max-width:28rem}}.flex-shrink-0{{flex-shrink:0}}.transform{{--tw-translate-x:0;--tw-translate-y:0;--tw-rotate:0;--tw-skew-x:0;--tw-skew-y:0;--tw-scale-x:1;--tw-scale-y:1;transform:translateX(var(--tw-translate-x)) translateY(var(--tw-translate-y)) rotate(var(--tw-rotate)) skewX(var(--tw-skew-x)) skewY(var(--tw-skew-y)) scaleX(var(--tw-scale-x)) scaleY(var(--tw-scale-y))}}.-skew-y-6{{--tw-skew-y:-6deg}}.list-disc{{list-style-type:disc}}.flex-col{{flex-direction:column}}.items-start{{align-items:flex-start}}.items-center{{align-items:center}}.justify-center{{justify-content:center}}.space-y-2>:not([hidden])~:not([hidden]){{--tw-space-y-reverse:0;margin-top:calc(0.5rem*(1 - var(--tw-space-y-reverse)));margin-bottom:calc(0.5rem*var(--tw-space-y-reverse))}}.space-y-4>:not([hidden])~:not([hidden]){{--tw-space-y-reverse:0;margin-top:calc(1rem*(1 - var(--tw-space-y-reverse)));margin-bottom:calc(1rem*var(--tw-space-y-reverse))}}.divide-y>:not([hidden])~:not([hidden]){{--tw-divide-y-reverse:0;border-top-width:calc(1px*(1 - var(--tw-divide-y-reverse)));border-bottom-width:calc(1px*var(--tw-divide-y-reverse))}}.divide-gray-200>:not([hidden])~:not([hidden]){{--tw-divide-opacity:1;border-color:rgba(229,231,235,var(--tw-divide-opacity))}}.bg-white{{--tw-bg-opacity:1;background-color:rgba(255,255,255,var(--tw-bg-opacity))}}.bg-gray-100{{--tw-bg-opacity:1;background-color:rgba(243,244,246,var(--tw-bg-opacity))}}.bg-gradient-to-r{{background-image:linear-gradient(90deg,var(--tw-gradient-stops))}}.from-cyan-400{{--tw-gradient-from:#22d3ee;--tw-gradient-stops:var(--tw-gradient-from),var(--tw-gradient-to,rgba(34,211,238,0))}}.to-sky-500{{--tw-gradient-to:#0ea5e9}}.px-4{{padding-left:1rem;padding-right:1rem}}.py-3{{padding-top:.75rem;padding-bottom:.75rem}}.py-6{{padding-top:1.5rem;padding-bottom:1.5rem}}.py-8{{padding-top:2rem;padding-bottom:2rem}}.py-10{{padding-top:2.5rem;padding-bottom:2.5rem}}.pt-6{{padding-top:1.5rem}}.text-sm{{font-size:.875rem;line-height:1.25rem}}.text-base{{font-size:1rem;line-height:1.5rem}}.font-bold{{font-weight:700}}.leading-6{{line-height:1.5rem}}.text-gray-700{{--tw-text-opacity:1;color:rgba(55,65,81,var(--tw-text-opacity))}}.text-gray-900{{--tw-text-opacity:1;color:rgba(17,24,39,var(--tw-text-opacity))}}.text-cyan-500{{--tw-text-opacity:1;color:rgba(6,182,212,var(--tw-text-opacity))}}.text-cyan-600{{--tw-text-opacity:1;color:rgba(8,145,178,var(--tw-text-opacity))}}.hover\:text-cyan-700:hover{{--tw-text-opacity:1;color:rgba(14,116,144,var(--tw-text-opacity))}}*,:after,:before{{--tw-shadow:0 0 transparent}}.shadow-lg{{--tw-shadow:0 10px 15px -3px rgba(0,0,0,0.1),0 4px 6px -2px rgba(0,0,0,0.05);box-shadow:var(--tw-ring-offset-shadow,0 0 transparent),var(--tw-ring-shadow,0 0 transparent),var(--tw-shadow)}}*,:after,:before{{--tw-ring-inset:var(--tw-empty,/*!*/ /*!*/);--tw-ring-offset-width:0px;--tw-ring-offset-color:#fff;--tw-ring-color:rgba(59,130,246,0.5);--tw-ring-offset-shadow:0 0 transparent;--tw-ring-shadow:0 0 transparent}}@media (min-width:640px){{.sm\:mx-auto{{margin-left:auto;margin-right:auto}}.sm\:h-7{{height:1.75rem}}.sm\:h-8{{height:2rem}}.sm\:max-w-xl{{max-width:36rem}}.sm\:-rotate-6{{--tw-rotate:-6deg}}.sm\:skew-y-0{{--tw-skew-y:0deg}}.sm\:rounded-3xl{{border-radius:1.5rem}}.sm\:p-20{{padding:5rem}}.sm\:py-12{{padding-top:3rem;padding-bottom:3rem}}.sm\:text-lg{{font-size:1.125rem}}.sm\:leading-7,.sm\:text-lg{{line-height:1.75rem}}}}</style>
                    <script>
                    var hasHtml = false
                    var hasCss = false
                    var visible = false
                    window.addEventListener('message', (e) => {{
                      if (typeof e.data.clear !== 'undefined') {{
                        setHtml()
                        setCss()
                        checkVisibility()
                        return
                      }}
                      if (typeof e.data.css !== 'undefined') {{
                        setCss(e.data.css)
                      }}
                      if (typeof e.data.html !== 'undefined') {{
                        setHtml(e.data.html)
                      }}
                      checkVisibility()
                    }})
                    function checkVisibility() {{
                      if (!visible && hasHtml && hasCss) {{
                        visible = true
                        document.body.style.display = ''
                      }} else if (visible && (!hasHtml || !hasCss)) {{
                        visible = false
                        document.body.style.display = 'none'
                      }}
                    }}
                    function setHtml(html) {{
                      if (typeof html === 'undefined') {{
                        document.body.innerHTML = ''
                        hasHtml = false
                      }} else {{
                        document.body.innerHTML = html
                        hasHtml = true
                      }}
                    }}
                    function setCss(css) {{
                      const style = document.getElementById('_style')
                      const newStyle = document.createElement('style')
                      newStyle.id = '_style'
                      newStyle.innerHTML = typeof css === 'undefined' ? '' : css
                      style.parentNode.replaceChild(newStyle, style)
                      hasCss = typeof css === 'undefined' ? false : true
                    }}
                    </script>
                  </head>
                  <body style=""""><!--
  Welcome to Tailwind Play, the official Tailwind CSS playground!

  Everything here works just like it does when you're running Tailwind locally
  with a real build pipeline. You can customize your config file, use features
  like `@apply`, or even add third-party plugins.

  Feel free to play with this example if you're just learning, or trash it and
  start from scratch if you know enough to be dangerous. Have fun!
-->
{div(class_("min-h-screen bg-gray-100 py-6 flex flex-col justify-center sm:py-12"),
  div(class_("relative py-3 sm:max-w-xl sm:mx-auto"),
    div(class_("absolute inset-0 bg-gradient-to-r from-cyan-400 to-sky-500 shadow-lg transform -skew-y-6 sm:skew-y-0 sm:-rotate-6 sm:rounded-3xl")),
    div(class_("relative px-4 py-10 bg-white shadow-lg sm:rounded-3xl sm:p-20"),
      div(class_("max-w-md mx-auto"),
        div(
          img(src("/img/logo.svg"), class_("h-7 sm:h-8"))
        ),
        div(class_("divide-y divide-gray-200"),
          div(class_("py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7"),
            p("An advanced online playground for Tailwind CSS, including support for things like:"),
            ul(class_("list-disc space-y-2"),
              li(class_("flex items-start"),
                span(class_("h-6 flex items-center sm:h-7"),
                  @"<svg class=""flex-shrink-0 h-5 w-5 text-cyan-500"" viewBox=""0 0 20 20"" fill=""currentColor"">
                    <path fill-rule=""evenodd"" d=""M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z"" clip-rule=""evenodd"" />
                  </svg>"
                ),
                p(class_("ml-2"),
                  "Customizing your",
                  code(class_("text-sm font-bold text-gray-900"), "tailwind.config.js"), "file"
                )
              ),
              li(class_("flex items-start"),
                span(class_("h-6 flex items-center sm:h-7"),
                  @"<svg class=""flex-shrink-0 h-5 w-5 text-cyan-500"" viewBox=""0 0 20 20"" fill=""currentColor"">
                    <path fill-rule=""evenodd"" d=""M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z"" clip-rule=""evenodd"" />
                  </svg>"
                ),
                p(class_("ml-2"),
                  "Extracting classes with",
                  code(class_("text-sm font-bold text-gray-900"), "@apply")
                )
              ),
              li(class_("flex items-start"),
                span(class_("h-6 flex items-center sm:h-7"),
                  @"<svg class=""flex-shrink-0 h-5 w-5 text-cyan-500"" viewBox=""0 0 20 20"" fill=""currentColor"">
                    <path fill-rule=""evenodd"" d=""M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z"" clip-rule=""evenodd"" />
                  </svg>"
                ),
                p(class_("ml-2"), "Code completion with instant preview")
              )
            ),
            p("Perfect for learning how the framework works, prototyping a new idea, or creating a demo to share online.")
          ),
          div(class_("pt-6 text-base leading-6 font-bold sm:text-lg sm:leading-7"),
            p("Want to dig deeper into Tailwind?"),
            p(
              a(href("https://tailwindcss.com/docs"), class_("text-cyan-600 hover:text-cyan-700"), "Read the docs →")
            )
          )
        )
      )
    )
  )
)}
</body></html>";

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            await page.GotoAsync("https://play.tailwindcss.com/");
            var iframe = await page.QuerySelectorAsync("iframe");
            var expected = await (await iframe!.ContentFrameAsync())!.ContentAsync();

            var diffs = DiffBuilder
                .Compare(expected)
                .WithTest(actual)
                .Build()
                .ToList();

            diffs.Should().BeEmpty();
        }

        [Test]
        public async Task statiq_web_examples()
        {
            // https://github.com/statiqdev/Statiq.Web
            // cd /examples/Statiq.Web.Examples
            // dotnet run -- preview

            dynamic input = new ExpandoObject();
            input.archives = new[]
            {
                new { Filename = "/archives/simple-archive.cshtml", Body = "" },
                new { Filename = "/archives/ordered-archive.cshtml", Body = "" },
                new { Filename = "/archives/paged-archive.cshtml", Body = "" },
                new { Filename = "/archives/grouped-archive.cshtml", Body = "" },
                new { Filename = "/archives/computed-order-archive.cshtml", Body = "" },
                new { Filename = "/archives/filtered-archive.cshtml", Body = "" },
                new { Filename = "/archives/computed-grouped-archive.cshtml", Body = "" },
            };
            input.archives_md = new
            {
                Filename = "archives.md",
                Title = "Archives Examples",
                Body =
$@"Examples of the [archives](https://statiq.dev/web/content-and-data/archives) feature.

<div>{ListPages(input.archives)}</div>
"
            };
            input.index_md = new
            {
                Filename = "index.md",
                Title = "Examples",
                Body =
$@"Examples demonstrating various aspects of [Statiq Web](https://statiq.dev/web).

<div>{ListPages([input.archives_md])}</div>
"
            };

            // index
            var actual = layout(input.index_md, new[] { input.archives_md });
            using var client = new HttpClient();
            var expected = await client.GetStringAsync("http://localhost:5080/");
            DiffBuilder
                .Compare(expected)
                .WithTest(actual)
                .Build()
                .ToList()
                .Should().BeEmpty();

            // archives
            actual = layout(input.archives_md, new[] { input.archives_md });
            expected = await client.GetStringAsync("http://localhost:5080/archives");
            DiffBuilder
                .Compare(expected)
                .WithTest(actual)
                .Build()
                .ToList()
                .Should().BeEmpty();

            static string layout(dynamic document, dynamic[] children)
            {
                return
$@"{html(
    head(
        meta(charset("utf-8")),
        meta(http_equiv("X-UA-Compatible"), content("IE=edge")),
        meta(name("viewport"), content("width=device-width, initial-scale=1")),
        link(rel("stylesheet"), href("https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css"), integrity("sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l"), crossorigin("anonymous"), new Attribute("data-no-mirror")),
        link(rel("stylesheet"), href("https://cdn.jsdelivr.net/npm/prismjs@1.19.0/themes/prism.css"), new Attribute("data-no-mirror")),
        Elements.title($"Archives Examples - {document.Title}")
    ),
    body(
        nav(class_("navbar navbar-light navbar-expand bg-light"),
            div(class_("container"),
                a(class_("navbar-brand"), href("/"), "Home"),
                div(class_("collapse navbar-collapse"),
                    ul(class_("navbar-nav"),
                        children.Each(child =>
                            li(class_("nav-item"),
                                a(class_("nav-link"), href(Url(child)), Title(child))
                            )
                        )
                    )
                )
            )
        ),
        div(class_("container"),
            div(class_("mt-4"),
                h1(document.Title),
                hr(),
                Markdown.ToHtml(document.Body)
            )
        ),
        "<script type=\"text/javascript\" src=\"/livereload.js?host=localhost&port=5080\"></script>"
    )
)}";
            }

            static string ListPages(dynamic[] children)
            {
                var result = string.Empty;
                foreach (dynamic page in children)
                {
                    result += DocumentLink(page);
                    result += Excerpt(page);
                }
                return result;
            }

            static string DocumentLink(dynamic document)
            {
                return h5(a(href(Url(document)), Title(document)));
            }

            static string Url(dynamic document)
            {
                if (document.Filename == "index.md") return "/";

                var url = document.Filename.Substring(0, document.Filename.LastIndexOf("."));

                return url.StartsWith("/") ? url : "/" + url;
            }

            static string Title(dynamic document)
            {
                if (Has(document, "Title")) return document.Title;

                string filename = document.Filename;
                var startIndex = filename.LastIndexOf("/") + 1;
                var length = filename.LastIndexOf(".") - startIndex;
                var name = filename.Substring(startIndex, length);

                return name.Humanize(LetterCasing.Title);
            }

            static string Excerpt(dynamic document)
            {
                var newLineIndex = document.Body.IndexOf('\n');

                return Markdown.ToHtml(newLineIndex > 0 ? document.Body.Substring(0, newLineIndex) : document.Body);
            }

            static bool Has(dynamic document, string property)
            {
                Type type = document.GetType();
                return type.GetProperties().Where(p => p.Name.Equals(property)).Any();
            }
        }
    }
}
