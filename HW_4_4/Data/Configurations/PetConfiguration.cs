using HW_4_4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW_4_4.Data.Configurations;

/// <summary>
/// Configurations for the pets table.
/// </summary>
public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    /// <summary>
    /// Used to configure the entity of type <see cref="Pet"/>.
    /// </summary>
    /// <param name="builder">The instance of <see cref="EntityTypeBuilder"/> class.</param>
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(pet => pet.Id);
        builder.Property(pet => pet.Name).IsRequired();
        builder.Property(pet => pet.Age).IsRequired();

        builder.HasOne(pet => pet.Location)
            .WithMany(location => location.Pets)
            .HasForeignKey(pet => pet.LocationId);

        builder.HasOne(pet => pet.Category)
            .WithMany(category => category.Pets)
            .HasForeignKey(pet => pet.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pet => pet.Breed)
            .WithMany(breed => breed.Pets)
            .HasForeignKey(pet => pet.BreedId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}