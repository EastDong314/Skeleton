using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using Skeleton.Entity;
using Skeleton.Exception;
using Skeleton.Models;
using Skeleton.Repository;
using Skeleton.Services;

namespace Skeleton.Test;

public class WeatherServiceTests
{
    private readonly IWeatherService _weatherService;
    private readonly Mock<IRepository<WeatherEntity>> _mockRepository;

    public WeatherServiceTests()
    {
        _mockRepository = new Mock<IRepository<WeatherEntity>>();
        _weatherService = new WeatherService(_mockRepository.Object);
    }
    
    [Fact]
    public async Task GivenExistDateWeather_WhenAddWeather_ThenThrowResourceAlreadyExistException()
    {
        //Arrange
        _mockRepository.Setup(r => r.CountAsync(It.IsAny<Expression<Func<WeatherEntity, bool>>>()))
            .ReturnsAsync(1);

        //Action

        var action = () => _weatherService.AddAsync(new WeatherDomainModel
        {
            Date = new DateOnly(2024, 9, 14),
            Temperature = 10
        });
        
        //Assert
        var exception = await action.Should().ThrowAsync<ResourceAlreadyExistException>();
        exception.WithMessage("Resource Already Exist");
        
        _mockRepository.Verify(r => r.CountAsync(It.IsAny<Expression<Func<WeatherEntity, bool>>>()), Times.Once);
        _mockRepository.Verify(r => r.AddAsync(It.IsAny<WeatherEntity>()), Times.Never);
    }
}