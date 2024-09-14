using Skeleton.Entity;
using Skeleton.Exception;
using Skeleton.Models;
using Skeleton.Repository;

namespace Skeleton.Services;

public class WeatherService(IRepository<WeatherEntity> repository) : IWeatherService
{
    public async Task<WeatherDomainModel> GetByDateAsync(DateOnly date)
    {
        var weather = await GetWeatherByDate(date);

        return weather.ToDomainModel();
    }

    public async Task AddAsync(WeatherDomainModel weather)
    {
        var specifyDataWeatherCount = await repository.CountAsync(w => w.Date.Equals(weather.Date));

        if (specifyDataWeatherCount > 0)
        {
            throw new ResourceAlreadyExistException();
        }

        await repository.AddAsync(weather.ToEntity());
    }

    public async Task RemoveByDateAsync(DateOnly date)
    {
        var weather = await GetWeatherByDate(date);

        await repository.RemoveAsync(weather);
    }
    
    private async Task<WeatherEntity> GetWeatherByDate(DateOnly date)
    {
        var weather = await repository.GetSingleOrDefaultAsync(w => w.Date.Equals(date));

        if (weather == default)
        {
            throw new ResourceNotFoundException();
        }

        return weather;
    }
}