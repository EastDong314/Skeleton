namespace Skeleton.Contracts.Response;

public class GetWeatherByDateResponseModel
{
    public DateOnly Date { get; set; }

    public int Temperature { get; set; }

    public int TemperatureF { get; set; }
}