using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Markupolation.Sample.Functions
{
    public class Weather
    {
        [Function("Weather")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            var forecasts = new[]
            {
                new { Date = DateTime.Parse("2018-05-06"), TemperatureC = 1, Summary = "Freezing" },
                new { Date = DateTime.Parse("2018-05-07"), TemperatureC = 14, Summary = "Bracing" },
                new { Date = DateTime.Parse("2018-05-08"), TemperatureC = -13, Summary = "Freezing" },
                new { Date = DateTime.Parse("2018-05-09"), TemperatureC = -16, Summary = "Balmy" },
                new { Date = DateTime.Parse("2018-05-10"), TemperatureC = -2, Summary = "Chilly" }
            };

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            response.WriteString(
                $@"<table class=""table"">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Temp. (C)</th>
                            <th>Temp. (F)</th>
                            <th>Summary</th>
                        </tr>
                    </thead>
                    <tbody>
                        {forecasts.Each(x => tr(
                            td(x.Date.ToShortDateString()),
                            td(x.TemperatureC),
                            td(TemperatureF(x)),
                            td(x.Summary)
                        ))}
                    </tbody>
                </table>"
            );

            return response;

            static int TemperatureF(dynamic forecast) => 32 + (int)(forecast.TemperatureC / 0.5556);
        }
    }
}
