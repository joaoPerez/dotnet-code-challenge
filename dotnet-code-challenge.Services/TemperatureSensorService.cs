using System.Threading.Tasks;
using System.Collections.Generic;
using dotnet_code_challenge.Domain.Interfaces.Services;
using dotnet_code_challenge.Domain.Models;
using dotnet_code_challenge.Domain.Interfaces.Repository;

namespace dotnet_code_challenge.Services
{
    public class TemperatureSensorService : ITemperatureSensorService
    {
        private readonly ITemperatureSensorRepository _temperatureSensorRepository;
        public TemperatureSensorService(ITemperatureSensorRepository temperatureSensorRepository)
        {
            _temperatureSensorRepository = temperatureSensorRepository;
        }

        public async Task<List<BeerModel>> GetBeerTemperatureStatus(List<BeerModel> beers)
        {
            List<string> beerIds = new List<string>(beers.Count);

            beers.ForEach(x => beerIds.Add(x.Id));

            List<SensorDto> sensors = await _temperatureSensorRepository.FindTemperatureStatus(beerIds);

            foreach (var sensor in sensors)
            {
                BeerModel beer = beers.Find(x => x.Id == sensor.Id);

                int temperature = sensor.Temperature;

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

            return beers;
        }
    }
}