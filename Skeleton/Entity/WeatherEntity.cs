using Skeleton.Models;

namespace Skeleton.Entity;

public class WeatherEntity : BaseEntity
{
    public DateOnly Date { get; set; }
    
    public int Temperature { get; set; }
}

public static class WeatherEntityExtensions
{
    public static WeatherDomainModel ToDomainModel(this WeatherEntity entity)
    {
        return new WeatherDomainModel
        {
            Date = entity.Date,
            Temperature = entity.Temperature
        };
    }
}