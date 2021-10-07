using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using dotnet_code_challenge.Domain.Models;

namespace dotnet_code_challenge.Domain.Interfaces.Services
{
    public interface ITemperatureSensorService
    {
         Task<List<BeerModel>> GetBeerTemperatureStatus(List<BeerModel> beers);
    }
}