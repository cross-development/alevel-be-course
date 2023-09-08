using HW_4_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_4_4.Data.Configurations;

/// <summary>
/// Configurations for the location table.
/// </summary>
public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    /// <summary>
    /// Used to configure the entity of type <see cref="Location"/>.
    /// </summary>
    /// <param name="builder">The instance of <see cref="EntityTypeBuilder"/> class.</param>
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(location => location.Id);
        builder.Property(location => location.LocationName).IsRequired();
    }
}