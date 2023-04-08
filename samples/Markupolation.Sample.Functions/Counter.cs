using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Markupolation.Sample.Functions
{
    public class Counter
    {
        [Function("Counter")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Counter/{count:int}")] HttpRequestData req, int count)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            response.WriteString($"{mark(a.title(count), Humanizer.NumberToWordsExtension.ToWords(count))}");

            return response;
        }
    }
}
