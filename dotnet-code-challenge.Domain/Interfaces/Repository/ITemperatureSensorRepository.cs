using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_code_challenge.Domain.Models;

namespace dotnet_code_challenge.Domain.Interfaces.Repository
{
    public interface ITemperatureSensorRepository
    {
         Task<List<SensorDto>> FindTemperatureStatus(List<string> beerIds);
    }
}