using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HW_4_5.Models;

namespace HW_4_5.Data.Configurations;

/// <summary>
/// Configurations for the location table.
/// </summary>
public sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    /// <summary>
    /// Used to configure the entity of type <see cref="Location"/>.
    /// </summary>
    /// <param name="builder">The instance of <see cref="EntityTypeBuilder"/> class.</param>
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(location => location.Id);
        builder.Property(location => location.Id).ValueGeneratedNever();
        builder.Property(location => location.LocationName).IsRequired();

        builder.HasData(
            new Location
            {
                Id = 1,
                LocationName = "Ukraine"
            },
            new Location
            {
                Id = 2,
                LocationName = "Poland"
            },
            new Location
            {
                Id = 3,
                LocationName = "Germany"
            },
            new Location
            {
                Id = 4,
                LocationName = "Italy"
            });
    }
}