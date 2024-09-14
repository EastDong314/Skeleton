using Microsoft.EntityFrameworkCore;
using Skeleton.Entity;
using Skeleton.Repository;
using Skeleton.Services;

namespace Skeleton;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        
        builder.Services.AddDbContext<SkeletonDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("Skeleton")));
        
        builder.Services.AddScoped<IWeatherService, WeatherService>();
        builder.Services.AddScoped<IRepository<WeatherEntity>, Repository<WeatherEntity>>();
        
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}