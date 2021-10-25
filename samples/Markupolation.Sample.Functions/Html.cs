using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Markupolation.Sample.Functions
{
    public static class Html
    {
        [FunctionName("Html")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            return new ContentResult
            {
                Content =
                    $@"{DOCTYPE() +
                    html(lang("en"),
                        head(
                            meta(charset("utf-8")),
                            e.title("Markupolation.Sample.Functions"),
                            meta(name("description"), content("Sample of how to use Markupolation in a net6.0 Azure Function")),
                            meta(name("viewport"), content("width=device-width, initial-scale=1"))
                        ),
                        body(
                            h1("Hello, World!"),
                            p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
                        )
                    )}",
                ContentType = "text/html"
            };
        }
    }
}
