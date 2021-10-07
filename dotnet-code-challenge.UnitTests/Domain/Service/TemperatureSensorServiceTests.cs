using System;
using Xunit;
using Moq;
using dotnet_code_challenge.Domain.Interfaces.Repository;
using dotnet_code_challenge.Domain.Interfaces.Services;
using System.Collections.Generic;
using dotnet_code_challenge.Domain.Models;
using System.Threading.Tasks;
using dotnet_code_challenge.Services;

namespace dotnet_code_challenge.UnitTests.Domain.Service
{
    public class TemperatureSensorServiceTests
    {
        private readonly Mock<ITemperatureSensorRepository> _temperatureSensorRepositoryMock;
        private readonly ITemperatureSensorService _temperatureSensorService;

        public TemperatureSensorServiceTests()
        {
            _temperatureSensorRepositoryMock = new Mock<ITemperatureSensorRepository>();
            _temperatureSensorService = new TemperatureSensorService(_temperatureSensorRepositoryMock.Object);
        }

        [Fact]
        public void GetBeerTemperatureStatus_TemperatureLessThanMinimium_ReturnsTooLow()
        {
            List<BeerModel> beers = new()
            {
                new BeerModel
                {
                    Id = "1",
                    Name = "Pilsner",
                    MinimumTemperature = 4,
                    MaximumTemperature = 6,
                    Temperature = 0,
                    TemperatureStatus = "",
                }
            };

            List<SensorDto> sensors = new List<SensorDto> { new SensorDto { Id = "1", Temperature = 2 } };

            _temperatureSensorRepositoryMock.Setup(t => t.FindTemperatureStatus(It.IsAny<List<string>>())).Returns(Task.FromResult(sensors));

            List<BeerModel> beerModels = _temperatureSensorService.GetBeerTemperatureStatus(beers).Result;

            Assert.Equal(beerModels[0].TemperatureStatus, "too low");
        }

        [Fact]
        public void GetBeerTemperatureStatus_TemperatureBigerThanMaximium_ReturnsTooHigh()
        {
            List<BeerModel> beers = new()
            {
                new BeerModel
                {
                    Id = "1",
                    Name = "Pilsner",
                    MinimumTemperature = 4,
                    MaximumTemperature = 6,
                    Temperature = 0,
                    TemperatureStatus = "",
                }
            };

            List<SensorDto> sensors = new List<SensorDto> { new SensorDto { Id = "1", Temperature = 8 } };

            _temperatureSensorRepositoryMock.Setup(t => t.FindTemperatureStatus(It.IsAny<List<string>>())).Returns(Task.FromResult(sensors));

            List<BeerModel> beerModels = _temperatureSensorService.GetBeerTemperatureStatus(beers).Result;

            Assert.Equal(beerModels[0].TemperatureStatus, "too high");
        }

        [Fact]
        public void GetBeerTemperatureStatus_TemperatureNormal_ReturnsAllGood()
        {
            List<BeerModel> beers = new()
            {
                new BeerModel
                {
                    Id = "1",
                    Name = "Pilsner",
                    MinimumTemperature = 4,
                    MaximumTemperature = 6,
                    Temperature = 0,
                    TemperatureStatus = "",
                }
            };

            List<SensorDto> sensors = new List<SensorDto> { new SensorDto { Id = "1", Temperature = 5 } };

            _temperatureSensorRepositoryMock.Setup(t => t.FindTemperatureStatus(It.IsAny<List<string>>())).Returns(Task.FromResult(sensors));

            List<BeerModel> beerModels = _temperatureSensorService.GetBeerTemperatureStatus(beers).Result;

            Assert.Equal(beerModels[0].TemperatureStatus, "all good");
        }
    }
}
