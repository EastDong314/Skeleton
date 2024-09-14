using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Skeleton.Entity.Configurations;

public class WeatherEntityConfiguration : EntityConfiguration
{
    public new void Configure(EntityTypeBuilder<WeatherEntity> builder)
    {
        base.Configure(builder);

        builder.HasIndex(b => b.Date).IsUnique();
        
        builder.Property(b => b.Temperature).IsRequired();
    }
}