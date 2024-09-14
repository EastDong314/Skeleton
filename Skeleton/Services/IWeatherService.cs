using Skeleton.Models;

namespace Skeleton.Services;

public interface IWeatherService
{
    Task<WeatherDomainModel> GetByDateAsync(DateOnly date);

    Task AddAsync(WeatherDomainModel weather);

    Task RemoveByDateAsync(DateOnly date);
}