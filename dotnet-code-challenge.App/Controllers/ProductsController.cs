using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCodeChallenge.Models;

namespace DotNetCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Beer> beers = new()
            {
                new Beer
                {
                    Id = "1",
                    Name = "Pilsner",
                    MinimumTemperature = 4,
                    MaximumTemperature = 6,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new Beer
                {
                    Id = "2",
                    Name = "IPA",
                    MinimumTemperature = 5,
                    MaximumTemperature = 6,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new Beer
                {
                    Id = "3",
                    Name = "Lager",
                    MinimumTemperature = 4,
                    MaximumTemperature = 7,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new Beer
                {
                    Id = "4",
                    Name = "Stout",
                    MinimumTemperature = 6,
                    MaximumTemperature = 8,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new Beer
                {
                    Id = "5",
                    Name = "Wheat beer",
                    MinimumTemperature = 3,
                    MaximumTemperature = 5,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new Beer
                {
                    Id = "6",
                    Name = "Pale Ale",
                    MinimumTemperature = 4,
                    MaximumTemperature = 6,
                    Temperature = 0,
                    TemperatureStatus = "",
                }
            };

            var http = new HttpClient();

            foreach (var beer in beers)
            {
                var response = await http.GetAsync("https://temperature-sensor-service.herokuapp.com/sensor/" + beer.Id);
                var jsonString = await response.Content.ReadAsStringAsync();
                var sensor = JsonSerializer.Deserialize<Sensor>(jsonString, new JsonSerializerOptions {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                beer.Temperature = sensor.Temperature;

                if (sensor.Temperature < beer.MinimumTemperature)
                {
                    beer.TemperatureStatus = "too low";
                }

                if (sensor.Temperature > beer.MaximumTemperature)
                {
                    beer.TemperatureStatus = "too high";
                }

                if (sensor.Temperature >= beer.MinimumTemperature && sensor.Temperature <= beer.MaximumTemperature)
                {
                    beer.TemperatureStatus = "all good";
                }
            }

            return Ok(beers);
        }
    }
}
