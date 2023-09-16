using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HW_4_6.Models;

namespace HW_4_6.Data.Configurations;

/// <summary>
/// Configurations for the breed table.
/// </summary>
public sealed class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    /// <summary>
    /// Used to configure the entity of type <see cref="Breed"/>.
    /// </summary>
    /// <param name="builder">The instance of <see cref="EntityTypeBuilder"/> class.</param>
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.HasKey(breed => breed.Id);
        builder.Property(breed => breed.Id).ValueGeneratedNever();
        builder.Property(breed => breed.BreedName).IsRequired();

        builder.HasOne(breed => breed.Category)
            .WithMany(category => category.Breeds)
            .HasForeignKey(breed => breed.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(
            new Breed
            {
                Id = 1,
                BreedName = "Dog Breed 1",
                CategoryId = 1,
            },
            new Breed
            {
                Id = 2,
                BreedName = "Cat Breed 1",
                CategoryId = 2,
            },
            new Breed
            {
                Id = 3,
                BreedName = "Parrot Breed 1",
                CategoryId = 3,
            },
            new Breed
            {
                Id = 4,
                BreedName = "Rodent Breed 1",
                CategoryId = 4,
            });
    }
}