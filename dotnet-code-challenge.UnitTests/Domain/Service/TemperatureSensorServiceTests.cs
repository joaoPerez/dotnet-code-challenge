using System;
using Xunit;
using Moq;
using dotnet_code_challenge.Domain.Interfaces.Repository;
using dotnet_code_challenge.Domain.Interfaces.Services;
using System.Collections.Generic;
using dotnet_code_challenge.Domain.Models;

namespace dotnet_code_challenge.UnitTests.Domain.Service
{
    public class TemperatureSensorServiceTests
    {
        private readonly Mock<ITemperatureSensorRepository> _temperatureSensorRepositoryMock;
        private readonly Mock<ITemperatureSensorService> _temperatureSensorServiceMock;

        public TemperatureSensorServiceTests()
        {
            _temperatureSensorRepositoryMock = new Mock<ITemperatureSensorRepository>();
        }

        [Fact]
        public void GetBeerTemperatureStatus_TemperatureLessThanMinimium_ReturnsTooLow()
        {



        }

        [Fact]
        public void GetBeerTemperatureStatus_TemperatureBigerThanMaximium_ReturnsTooHigh()
        {

        }

        [Fact]
        public void GetBeerTemperatureStatus_TemperatureNormal_ReturnsAllGood()
        {

        }
    }
}
