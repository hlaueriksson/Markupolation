using System;
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
        meta(name("viewport"), content("width=device-width, initial-scale=1")),
        Elements.title(""),
        link(rel("stylesheet"), href("css/style.css")),
        meta(name("description"), content("")),

        meta(new Attribute("property", "og:title"), content("")),
        meta(new Attribute("property", "og:type"), content("")),
        meta(new Attribute("property", "og:url"), content("")),
        meta(new Attribute("property", "og:image"), content("")),

        link(rel("icon"), href("/favicon.ico"), sizes("any")),
        link(rel("icon"), href("/icon.svg"), type("image/svg+xml")),
        link(rel("apple-touch-icon"), href("icon.png")),

        link(rel("manifest"), href("site.webmanifest")),
        meta(name("theme-color"), content("#fafafa"))
    ),
    body(

        "<!-- Add your site or application content here -->",
        p("Hello world! This is HTML5 Boilerplate."),
        script(src("js/app.js"))
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
html(lang("en"), data("bs-theme", "auto"),
    head(
        script(src("/docs/5.3/assets/js/color-modes.js")),
        meta(charset("utf-8")),
        meta(name("viewport"), content("width=device-width, initial-scale=1")),
        meta(name("description"), content("")),
        meta(name("author"), content("Mark Otto, Jacob Thornton, and Bootstrap contributors")),
        meta(name("generator"), content("Hugo 0.118.2")),
        Elements.title("Starter Template · Bootstrap v5.3"),

        link(rel("canonical"), href("https://getbootstrap.com/docs/5.3/examples/starter-template/")),

        link(rel("stylesheet"), href("https://cdn.jsdelivr.net/npm/@docsearch/css@3")),

        link(href("/docs/5.3/dist/css/bootstrap.min.css"), rel("stylesheet"), integrity("sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN"), crossorigin("anonymous")),

        "<!-- Favicons -->",
        link(rel("apple-touch-icon"), href("/docs/5.3/assets/img/favicons/apple-touch-icon.png"), sizes("180x180")),
        link(rel("icon"), href("/docs/5.3/assets/img/favicons/favicon-32x32.png"), sizes("32x32"), type("image/png")),
        link(rel("icon"), href("/docs/5.3/assets/img/favicons/favicon-16x16.png"), sizes("16x16"), type("image/png")),
        link(rel("manifest"), href("/docs/5.3/assets/img/favicons/manifest.json")),
        link(rel("mask-icon"), href("/docs/5.3/assets/img/favicons/safari-pinned-tab.svg"), color("#712cf9")),
        link(rel("icon"), href("/docs/5.3/assets/img/favicons/favicon.ico")),
        meta(name("theme-color"), content("#712cf9")),

        Elements.style(
            """
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

            .b-example-divider {
              width: 100%;
              height: 3rem;
              background-color: rgba(0, 0, 0, .1);
              border: solid rgba(0, 0, 0, .15);
              border-width: 1px 0;
              box-shadow: inset 0 .5em 1.5em rgba(0, 0, 0, .1), inset 0 .125em .5em rgba(0, 0, 0, .15);
            }

            .b-example-vr {
              flex-shrink: 0;
              width: 1.5rem;
              height: 100vh;
            }

            .bi {
              vertical-align: -.125em;
              fill: currentColor;
            }

            .nav-scroller {
              position: relative;
              z-index: 2;
              height: 2.75rem;
              overflow-y: hidden;
            }

            .nav-scroller .nav {
              display: flex;
              flex-wrap: nowrap;
              padding-bottom: 1rem;
              margin-top: -1px;
              overflow-x: auto;
              text-align: center;
              white-space: nowrap;
              -webkit-overflow-scrolling: touch;
            }

            .btn-bd-primary {
              --bd-violet-bg: #712cf9;
              --bd-violet-rgb: 112.520718, 44.062154, 249.437846;

              --bs-btn-font-weight: 600;
              --bs-btn-color: var(--bs-white);
              --bs-btn-bg: var(--bd-violet-bg);
              --bs-btn-border-color: var(--bd-violet-bg);
              --bs-btn-hover-color: var(--bs-white);
              --bs-btn-hover-bg: #6528e0;
              --bs-btn-hover-border-color: #6528e0;
              --bs-btn-focus-shadow-rgb: var(--bd-violet-rgb);
              --bs-btn-active-color: var(--bs-btn-hover-color);
              --bs-btn-active-bg: #5a23c8;
              --bs-btn-active-border-color: #5a23c8;
            }

            .bd-mode-toggle {
              z-index: 1500;
            }

            .bd-mode-toggle .dropdown-menu .active .bi {
              display: block !important;
            }
            """
        )
    ),
    body(
        """
        <svg xmlns="http://www.w3.org/2000/svg" class="d-none">
          <symbol id="check2" viewBox="0 0 16 16">
            <path d="M13.854 3.646a.5.5 0 0 1 0 .708l-7 7a.5.5 0 0 1-.708 0l-3.5-3.5a.5.5 0 1 1 .708-.708L6.5 10.293l6.646-6.647a.5.5 0 0 1 .708 0z"/>
          </symbol>
          <symbol id="circle-half" viewBox="0 0 16 16">
            <path d="M8 15A7 7 0 1 0 8 1v14zm0 1A8 8 0 1 1 8 0a8 8 0 0 1 0 16z"/>
          </symbol>
          <symbol id="moon-stars-fill" viewBox="0 0 16 16">
            <path d="M6 .278a.768.768 0 0 1 .08.858 7.208 7.208 0 0 0-.878 3.46c0 4.021 3.278 7.277 7.318 7.277.527 0 1.04-.055 1.533-.16a.787.787 0 0 1 .81.316.733.733 0 0 1-.031.893A8.349 8.349 0 0 1 8.344 16C3.734 16 0 12.286 0 7.71 0 4.266 2.114 1.312 5.124.06A.752.752 0 0 1 6 .278z"/>
            <path d="M10.794 3.148a.217.217 0 0 1 .412 0l.387 1.162c.173.518.579.924 1.097 1.097l1.162.387a.217.217 0 0 1 0 .412l-1.162.387a1.734 1.734 0 0 0-1.097 1.097l-.387 1.162a.217.217 0 0 1-.412 0l-.387-1.162A1.734 1.734 0 0 0 9.31 6.593l-1.162-.387a.217.217 0 0 1 0-.412l1.162-.387a1.734 1.734 0 0 0 1.097-1.097l.387-1.162zM13.863.099a.145.145 0 0 1 .274 0l.258.774c.115.346.386.617.732.732l.774.258a.145.145 0 0 1 0 .274l-.774.258a1.156 1.156 0 0 0-.732.732l-.258.774a.145.145 0 0 1-.274 0l-.258-.774a1.156 1.156 0 0 0-.732-.732l-.774-.258a.145.145 0 0 1 0-.274l.774-.258c.346-.115.617-.386.732-.732L13.863.1z"/>
          </symbol>
          <symbol id="sun-fill" viewBox="0 0 16 16">
            <path d="M8 12a4 4 0 1 0 0-8 4 4 0 0 0 0 8zM8 0a.5.5 0 0 1 .5.5v2a.5.5 0 0 1-1 0v-2A.5.5 0 0 1 8 0zm0 13a.5.5 0 0 1 .5.5v2a.5.5 0 0 1-1 0v-2A.5.5 0 0 1 8 13zm8-5a.5.5 0 0 1-.5.5h-2a.5.5 0 0 1 0-1h2a.5.5 0 0 1 .5.5zM3 8a.5.5 0 0 1-.5.5h-2a.5.5 0 0 1 0-1h2A.5.5 0 0 1 3 8zm10.657-5.657a.5.5 0 0 1 0 .707l-1.414 1.415a.5.5 0 1 1-.707-.708l1.414-1.414a.5.5 0 0 1 .707 0zm-9.193 9.193a.5.5 0 0 1 0 .707L3.05 13.657a.5.5 0 0 1-.707-.707l1.414-1.414a.5.5 0 0 1 .707 0zm9.193 2.121a.5.5 0 0 1-.707 0l-1.414-1.414a.5.5 0 0 1 .707-.707l1.414 1.414a.5.5 0 0 1 0 .707zM4.464 4.465a.5.5 0 0 1-.707 0L2.343 3.05a.5.5 0 1 1 .707-.707l1.414 1.414a.5.5 0 0 1 0 .708z"/>
          </symbol>
        </svg>
        """,
        div(class_("dropdown position-fixed bottom-0 end-0 mb-3 me-3 bd-mode-toggle"),
          button(class_("btn btn-bd-primary py-2 dropdown-toggle d-flex align-items-center"),
                  id("bd-theme"),
                  type("button"),
                  new Attribute("aria-expanded", "false"),
                  data("bs-toggle", "dropdown"),
                  new Attribute("aria-label", "Toggle theme (auto)"),
            @"<svg class=""bi my-1 theme-icon-active"" width=""1em"" height=""1em""><use href=""#circle-half""></use></svg>",
            span(class_("visually-hidden"), id("bd-theme-text"), "Toggle theme")
          ),
          ul(class_("dropdown-menu dropdown-menu-end shadow"), new Attribute("aria-labelledby", "bd-theme-text"),
            li(
              button(type("button"), class_("dropdown-item d-flex align-items-center"), data("bs-theme-value", "light"), new Attribute("aria-pressed", "false"),
                @"<svg class=""bi me-2 opacity-50 theme-icon"" width=""1em"" height=""1em""><use href=""#sun-fill""></use></svg>",
                "Light",
                @"<svg class=""bi ms-auto d-none"" width=""1em"" height=""1em""><use href=""#check2""></use></svg>"
              )
            ),
            li(
              button(type("button"), class_("dropdown-item d-flex align-items-center"), data("bs-theme-value", "dark"), new Attribute("aria-pressed", "false"),
                @"<svg class=""bi me-2 opacity-50 theme-icon"" width=""1em"" height=""1em""><use href=""#moon-stars-fill""></use></svg>",
                "Dark",
                @"<svg class=""bi ms-auto d-none"" width=""1em"" height=""1em""><use href=""#check2""></use></svg>"
              )
            ),
            li(
              button(type("button"), class_("dropdown-item d-flex align-items-center active"), data("bs-theme-value", "auto"), new Attribute("aria-pressed", "true"),
                @"<svg class=""bi me-2 opacity-50 theme-icon"" width=""1em"" height=""1em""><use href=""#circle-half""></use></svg>",
                "Auto",
                @"<svg class=""bi ms-auto d-none"" width=""1em"" height=""1em""><use href=""#check2""></use></svg>"
              )
            )
          )
        ),
        """
        <svg xmlns="http://www.w3.org/2000/svg" class="d-none">
          <symbol id="arrow-right-circle" viewBox="0 0 16 16">
            <path d="M8 0a8 8 0 1 1 0 16A8 8 0 0 1 8 0zM4.5 7.5a.5.5 0 0 0 0 1h5.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H4.5z"/>
          </symbol>
          <symbol id="bootstrap" viewBox="0 0 118 94">
            <title>Bootstrap</title>
            <path fill-rule="evenodd" clip-rule="evenodd" d="M24.509 0c-6.733 0-11.715 5.893-11.492 12.284.214 6.14-.064 14.092-2.066 20.577C8.943 39.365 5.547 43.485 0 44.014v5.972c5.547.529 8.943 4.649 10.951 11.153 2.002 6.485 2.28 14.437 2.066 20.577C12.794 88.106 17.776 94 24.51 94H93.5c6.733 0 11.714-5.893 11.491-12.284-.214-6.14.064-14.092 2.066-20.577 2.009-6.504 5.396-10.624 10.943-11.153v-5.972c-5.547-.529-8.934-4.649-10.943-11.153-2.002-6.484-2.28-14.437-2.066-20.577C105.214 5.894 100.233 0 93.5 0H24.508zM80 57.863C80 66.663 73.436 72 62.543 72H44a2 2 0 01-2-2V24a2 2 0 012-2h18.437c9.083 0 15.044 4.92 15.044 12.474 0 5.302-4.01 10.049-9.119 10.88v.277C75.317 46.394 80 51.21 80 57.863zM60.521 28.34H49.948v14.934h8.905c6.884 0 10.68-2.772 10.68-7.727 0-4.643-3.264-7.207-9.012-7.207zM49.948 49.2v16.458H60.91c7.167 0 10.964-2.876 10.964-8.281 0-5.406-3.903-8.178-11.425-8.178H49.948z"></path>
          </symbol>
        </svg>
        """,
        div(class_("col-lg-8 mx-auto p-4 py-md-5"),
          header(class_("d-flex align-items-center pb-3 mb-5 border-bottom"),
            a(href("/"), class_("d-flex align-items-center text-body-emphasis text-decoration-none"),
              @"<svg class=""bi me-2"" width=""40"" height=""32""><use xlink:href=""#bootstrap""/></svg>",
              span(class_("fs-4"), "Starter template")
            )
          ),

          main(
            h1(class_("text-body-emphasis"), "Get started with Bootstrap"),
            p(class_("fs-5 col-md-8"), "Quickly and easily get started with Bootstrap's compiled, production-ready files with this barebones example featuring some basic HTML and helpful links. Download all our examples to get started."),

            div(class_("mb-5"),
              a(href("/docs/5.3/examples/"), class_("btn btn-primary btn-lg px-4"), "Download examples")
            ),

            hr(class_("col-3 col-md-2 mb-5")),

            div(class_("row g-5"),
              div(class_("col-md-6"),
                h2(class_("text-body-emphasis"), "Starter projects"),
                p("Ready to go beyond the starter template? Check out these open source projects that you can quickly duplicate to a new GitHub repository."),
                ul(class_("list-unstyled ps-0"),
                  li(
                    a(class_("icon-link mb-1"), href("https://github.com/twbs/examples/tree/main/icons-font"), rel("noopener"), target("_blank"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Bootstrap npm starter"
                    )
                  ),
                  li(
                    a(class_("icon-link mb-1"), href("https://github.com/twbs/examples/tree/main/parcel"), rel("noopener"), target("_blank"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Bootstrap Parcel starter"
                    )
                  ),
                  li(
                    a(class_("icon-link mb-1"), href("https://github.com/twbs/examples/tree/main/vite"), rel("noopener"), target("_blank"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Bootstrap Vite starter"
                    )
                  ),
                  li(
                    a(class_("icon-link mb-1"), href("https://github.com/twbs/examples/tree/main/webpack"), rel("noopener"), target("_blank"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Bootstrap Webpack starter"
                    )
                  )
                )
              ),

              div(class_("col-md-6"),
                h2(class_("text-body-emphasis"), "Guides"),
                p("Read more detailed instructions and documentation on using or contributing to Bootstrap."),
                ul(class_("list-unstyled ps-0"),
                  li(
                    a(class_("icon-link mb-1"), href("/docs/5.3/getting-started/introduction/"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Bootstrap quick start guide"
                    )
                  ),
                  li(
                    a(class_("icon-link mb-1"), href("/docs/5.3/getting-started/webpack/"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Bootstrap Webpack guide"
                    )
                  ),
                  li(
                    a(class_("icon-link mb-1"), href("/docs/5.3/getting-started/parcel/"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Bootstrap Parcel guide"
                    )
                  ),
                  li(
                    a(class_("icon-link mb-1"), href("/docs/5.3/getting-started/vite/"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Bootstrap Vite guide"
                    )
                  ),
                  li(
                    a(class_("icon-link mb-1"), href("/docs/5.3/getting-started/contribute/"),
                      @"<svg class=""bi"" width=""16"" height=""16""><use xlink:href=""#arrow-right-circle""/></svg>",
                      "Contributing to Bootstrap"
                    )
                  )
                )
              )
            )
          ),
          footer(class_("pt-5 my-5 text-body-secondary border-top"),
            "Created by the Bootstrap team &middot; &copy; 2023"
          )
        ),
        script(src("/docs/5.3/dist/js/bootstrap.bundle.min.js"), integrity("sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL"), crossorigin("anonymous"))
    )
)}";

            using var client = new HttpClient();
            var expected = await client.GetStringAsync("https://getbootstrap.com/docs/5.3/examples/starter-template/");

            var diffs = DiffBuilder
                .Compare(expected)
                .WithTest(actual)
                .Build()
                .ToList();

            diffs.Should().BeEmpty();
        }

        /// <summary>
        /// Prerequisites:
        /// 1. Build
        /// 2. Install Playwright:
        ///    - pwsh bin/Debug/net8.0/playwright.ps1 install
        /// </summary>
        [Test]
        public async Task tailwind_play()
        {
            var actual =
$@"
<!--
  Welcome to Tailwind Play, the official Tailwind CSS playground!

  Everything here works just like it does when you're running Tailwind locally
  with a real build pipeline. You can customize your config file, use features
  like `@apply`, or even add third-party plugins.

  Feel free to play with this example if you're just learning, or trash it and
  start from scratch if you know enough to be dangerous. Have fun!
-->
{div(class_("relative flex min-h-screen flex-col justify-center overflow-hidden bg-gray-50 py-6 sm:py-12"),
  img(src("/img/beams.jpg"), alt(""), class_("absolute top-1/2 left-1/2 max-w-none -translate-x-1/2 -translate-y-1/2"), width("1308")),
  div(class_("absolute inset-0 bg-[url(/img/grid.svg)] bg-center [mask-image:linear-gradient(180deg,white,rgba(255,255,255,0))]")),
  div(class_("relative bg-white px-6 pt-10 pb-8 shadow-xl ring-1 ring-gray-900/5 sm:mx-auto sm:max-w-lg sm:rounded-lg sm:px-10"),
    div(class_("mx-auto max-w-md"),
      img(src("/img/logo.svg"), class_("h-6"), alt("Tailwind Play")),
      div(class_("divide-y divide-gray-300/50"),
        div(class_("space-y-6 py-8 text-base leading-7 text-gray-600"),
          p("An advanced online playground for Tailwind CSS, including support for things like:"),
          ul(class_("space-y-4"),
            li(class_("flex items-center"),
                """
                <svg class="h-6 w-6 flex-none fill-sky-100 stroke-sky-500 stroke-2" stroke-linecap="round" stroke-linejoin="round">
                  <circle cx="12" cy="12" r="11" />
                  <path d="m8 13 2.165 2.165a1 1 0 0 0 1.521-.126L16 9" fill="none" />
                </svg>
                """,
              p(class_("ml-4"),
                "Customizing your",
                code(class_("text-sm font-bold text-gray-900"), "tailwind.config.js"), "file"
              )
            ),
            li(class_("flex items-center"),
                """
                <svg class="h-6 w-6 flex-none fill-sky-100 stroke-sky-500 stroke-2" stroke-linecap="round" stroke-linejoin="round">
                  <circle cx="12" cy="12" r="11" />
                  <path d="m8 13 2.165 2.165a1 1 0 0 0 1.521-.126L16 9" fill="none" />
                </svg>
                """,
              p(class_("ml-4"),
                "Extracting classes with",
                code(class_("text-sm font-bold text-gray-900"), "@apply")
              )
            ),
            li(class_("flex items-center"),
                """
                <svg class="h-6 w-6 flex-none fill-sky-100 stroke-sky-500 stroke-2" stroke-linecap="round" stroke-linejoin="round">
                  <circle cx="12" cy="12" r="11" />
                  <path d="m8 13 2.165 2.165a1 1 0 0 0 1.521-.126L16 9" fill="none" />
                </svg>
                """,
              p(class_("ml-4"), "Code completion with instant preview")
            )
          ),
          p("Perfect for learning how the framework works, prototyping a new idea, or creating a demo to share online.")
        ),
        div(class_("pt-8 text-base font-semibold leading-7"),
          p(class_("text-gray-900"), "Want to dig deeper into Tailwind?"),
          p(
            a(href("https://tailwindcss.com/docs"), class_("text-sky-500 hover:text-sky-600"), "Read the docs &rarr;")
          )
        )
      )
    )
  )
)}";

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var context = await browser.NewContextAsync();
            await context.GrantPermissionsAsync(["clipboard-read", "clipboard-write"]);
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://play.tailwindcss.com/");
            await page.Locator(".SplitPane.horizontal").HoverAsync();
            await page.Locator("button :text('Copy')").First.ClickAsync();
            var expected = await page.EvaluateAsync<string>("navigator.clipboard.readText()");

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

            var archives = new[]
            {
                new { Filename = "/archives/paged-archive.cshtml" },
                new { Filename = "/archives/simple-archive.cshtml" },
                new { Filename = "/archives/ordered-archive.cshtml" },
                new { Filename = "/archives/filtered-archive.cshtml" },
                new { Filename = "/archives/grouped-archive.cshtml" },
                new { Filename = "/archives/computed-order-archive.cshtml" },
                new { Filename = "/archives/computed-grouped-archive.cshtml" },
            };
            var archivesPage = new
            {
                Filename = "archives.md",
                Title = "Archives Examples",
                Body =
                    $"""
                    Examples of the [archives](https://statiq.dev/web/content-and-data/archives) feature.
                    <div>{ListPages(archives)}</div>
                    """
            };
            var indexPage = new
            {
                Filename = "index.md",
                Title = "Statiq Web Examples",
                Body =
                    $"""
                    Examples demonstrating various aspects of [Statiq Web](https://statiq.dev/web).
                    <div>{ListPages([archivesPage])}</div>
                    """
            };

            // index
            var actual = layout(indexPage, new[] { archivesPage });
            using var client = new HttpClient();
            var expected = await client.GetStringAsync("http://localhost:5080/");
            DiffBuilder
                .Compare(expected)
                .WithTest(actual)
                .Build()
                .ToList()
                .Should().BeEmpty();

            // archives
            actual = layout(archivesPage, new[] { archivesPage });
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
                var startIndex = filename.LastIndexOf('/') + 1;
                var length = filename.LastIndexOf('.') - startIndex;
                var name = filename.Substring(startIndex, length);

                return name.Humanize(LetterCasing.Title);
            }

            static string Excerpt(dynamic document)
            {
                if (!Has(document, "Body")) return string.Empty;

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
