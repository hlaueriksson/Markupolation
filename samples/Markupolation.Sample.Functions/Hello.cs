using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Markupolation.Sample.Functions
{
    public static class Hello
    {
        [FunctionName("Hello")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            return new ContentResult
            {
                Content = $"{h1("Hello, World!") + p("This is ", mark(title("Markup with string interpolation"), "Markupolation"), " in action.")}",
                ContentType = "text/html"
            };
        }
    }
}
