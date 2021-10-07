using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using dotnet_code_challenge.Domain.Interfaces.Repository;
using dotnet_code_challenge.Domain.Models;

namespace dotnet_code_challenge.Infrastructure.Repository
{
    public class TemperatureSensorRepository : ITemperatureSensorRepository
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<SensorDto>> FindTemperatureStatus(List<string> beerIds)
        {
            List<SensorDto> sensors = new List<SensorDto>(beerIds.Count);

            foreach (var id in beerIds)
            {
                var response = await _httpClient.GetAsync("https://temperature-sensor-service.herokuapp.com/sensor/" + id);
                var jsonString = await response.Content.ReadAsStringAsync();

                var sensor = JsonSerializer.Deserialize<SensorDto>(jsonString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if(sensor == null) throw new ArgumentNullException("Error searching beer temperature");

                sensors.Add(sensor);
            }

            return sensors;
        }
    }
}