using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System;

namespace Markupolation.Sample.Functions
{
    public static class Weather
    {
        [FunctionName("Weather")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            var forecasts = new[]
            {
                new { Date = DateTime.Parse("2018-05-06"), TemperatureC = 1, Summary = "Freezing" },
                new { Date = DateTime.Parse("2018-05-07"), TemperatureC = 14, Summary = "Bracing" },
                new { Date = DateTime.Parse("2018-05-08"), TemperatureC = -13, Summary = "Freezing" },
                new { Date = DateTime.Parse("2018-05-09"), TemperatureC = -16, Summary = "Balmy" },
                new { Date = DateTime.Parse("2018-05-10"), TemperatureC = -2, Summary = "Chilly" }
            };

            return new ContentResult
            {
                Content =
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
                                td(x.TemperatureC.ToString()),
                                td(TemperatureF(x).ToString()),
                                td(x.Summary)
                            ))}
                        </tbody>
                    </table>",
                ContentType = "text/html"
            };
        }

        static int TemperatureF(dynamic forecast) => 32 + (int)(forecast.TemperatureC / 0.5556);
    }
}
