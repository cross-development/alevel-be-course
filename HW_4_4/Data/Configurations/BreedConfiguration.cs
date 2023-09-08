using HW_4_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_4_4.Data.Configurations;

/// <summary>
/// Configurations for the breed table.
/// </summary>
public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    /// <summary>
    /// Used to configure the entity of type <see cref="Breed"/>.
    /// </summary>
    /// <param name="builder">The instance of <see cref="EntityTypeBuilder"/> class.</param>
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.HasKey(breed => breed.Id);
        builder.Property(breed => breed.BreedName).IsRequired();

        builder.HasOne(breed => breed.Category)
            .WithMany(category => category.Breeds)
            .HasForeignKey(breed => breed.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}