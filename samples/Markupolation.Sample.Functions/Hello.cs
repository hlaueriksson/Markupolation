using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Markupolation.Sample.Functions
{
    public class Hello
    {
        [Function("Hello")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            response.WriteString($"{h1("Hello, World!") + p("This is ", mark(title("Markup with string interpolation"), "Markupolation"), " in action.")}");

            return response;
        }
    }
}
