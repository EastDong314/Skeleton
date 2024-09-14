using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Skeleton.Entity.Configurations;

public class EntityConfiguration : IEntityTypeConfiguration<WeatherEntity>
{
    public void Configure(EntityTypeBuilder<WeatherEntity> builder)
    {
        builder.HasKey(b => b.Id);
    }
}