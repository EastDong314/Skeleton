using Skeleton.Entity;

namespace Skeleton.Models;

public class WeatherDomainModel
{
    public DateOnly Date { get; set; }

    public int Temperature { get; set; }

    public int TemperatureF => 32 + (int)(Temperature / 0.5556);
}

public static class WeatherDomainModelExtensions
{
    public static WeatherEntity ToEntity(this WeatherDomainModel weather)
    {
        return new WeatherEntity
        {
            Id = Guid.NewGuid(),
            Date = weather.Date,
            Temperature = weather.Temperature
        };
    }
}