using Microsoft.AspNetCore.Mvc;
using Skeleton.Models;
using Skeleton.Services;

namespace Skeleton.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger) : ControllerBase
{
    private readonly ILogger<WeatherController> _logger = logger;
    private readonly IWeatherService _weatherService = weatherService;

    [HttpGet("/{date}")]
    public Task<WeatherDomainModel> Get(DateOnly date)
    {
        return _weatherService.GetByDateAsync(date);
    }
}