using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCodeChallenge.Models;
using dotnet_code_challenge.Domain.Interfaces;
using dotnet_code_challenge.Domain.Interfaces.Services;
using dotnet_code_challenge.Domain.Models;

namespace DotNetCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ITemperatureSensorService _temperatureSensorService;

        public ProductsController(ITemperatureSensorService temperatureSensorService)
        {
            _temperatureSensorService = temperatureSensorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<BeerModel> beers = new()
            {
                new BeerModel
                {
                    Id = "1",
                    Name = "Pilsner",
                    MinimumTemperature = 4,
                    MaximumTemperature = 6,
                    Temperature = 2,
                    TemperatureStatus = "",
                },

                new BeerModel
                {
                    Id = "2",
                    Name = "IPA",
                    MinimumTemperature = 5,
                    MaximumTemperature = 6,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new BeerModel
                {
                    Id = "3",
                    Name = "Lager",
                    MinimumTemperature = 4,
                    MaximumTemperature = 7,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new BeerModel
                {
                    Id = "4",
                    Name = "Stout",
                    MinimumTemperature = 6,
                    MaximumTemperature = 8,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new BeerModel
                {
                    Id = "5",
                    Name = "Wheat beer",
                    MinimumTemperature = 3,
                    MaximumTemperature = 5,
                    Temperature = 0,
                    TemperatureStatus = "",
                },

                new BeerModel
                {
                    Id = "6",
                    Name = "Pale Ale",
                    MinimumTemperature = 4,
                    MaximumTemperature = 6,
                    Temperature = 0,
                    TemperatureStatus = "",
                }
            };

            beers = await _temperatureSensorService.GetBeerTemperatureStatus(beers);

            return Ok(beers);
        }
    }
}
