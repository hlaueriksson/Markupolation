using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Markupolation.Sample.Functions
{
    public class Html
    {
        [Function("Html")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            response.WriteString(
                $@"{DOCTYPE() +
                html(lang("en"),
                    head(
                        meta(charset("utf-8")),
                        e.title("Markupolation.Sample.Functions"),
                        meta(name("description"), content("Sample of how to use Markupolation in a net6.0 Azure Function")),
                        meta(name("viewport"), content("width=device-width, initial-scale=1"))
                    ),
                    body(onload("console.log('Markupolation in a net6.0 Azure Function');"),
                        h1("Hello, World!"),
                        p("This is ", mark(a.title("Markup with string interpolation"), "Markupolation"), " in action.")
                    )
                )}"
            );

            return response;
        }
    }
}
