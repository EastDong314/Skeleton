using Microsoft.EntityFrameworkCore;
using Skeleton.Entity;

namespace Skeleton.Repository;

public class SkeletonDbContext(DbContextOptions<SkeletonDbContext> options) : DbContext(options)
{
    public DbSet<WeatherEntity> Weather { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkeletonDbContext).Assembly);
    }
}