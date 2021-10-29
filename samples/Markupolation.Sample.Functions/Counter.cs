using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Markupolation.Sample.Functions
{
    public static class Counter
    {
        [FunctionName("Counter")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Counter/{count:int}")] HttpRequest req, int count)
        {
            return new ContentResult
            {
                Content = $"{mark(a.title(count), Humanizer.NumberToWordsExtension.ToWords(count))}",
                ContentType = "text/html"
            };
        }
    }
}
