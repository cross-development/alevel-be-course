using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HW_4_5.Models;

namespace HW_4_5.Data.Configurations;

/// <summary>
/// Configurations for the pets table.
/// </summary>
public sealed class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    /// <summary>
    /// Used to configure the entity of type <see cref="Pet"/>.
    /// </summary>
    /// <param name="builder">The instance of <see cref="EntityTypeBuilder"/> class.</param>
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(pet => pet.Id);
        builder.Property(pet => pet.Id).ValueGeneratedNever();
        builder.Property(pet => pet.Name).IsRequired();
        builder.Property(pet => pet.Age).IsRequired();

        builder.HasOne(pet => pet.Location)
            .WithMany(location => location.Pets)
            .HasForeignKey(pet => pet.LocationId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(pet => pet.Category)
            .WithMany(category => category.Pets)
            .HasForeignKey(pet => pet.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(pet => pet.Breed)
            .WithMany(breed => breed.Pets)
            .HasForeignKey(pet => pet.BreedId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(
            new Pet
            {
                Id = 1,
                Name = "Dog 1",
                Age = 4,
                Description = "Some description about dog 1.",
                ImageUrl = "https://cdn.pixabay.com/photo/2021/04/21/21/03/dog-6197571_960_720.jpg",
                LocationId = 1,
                BreedId = 1,
                CategoryId = 1
            },
            new Pet
            {
                Id = 2,
                Name = "Cat 1",
                Age = 3,
                Description = "Some description about cat 1.",
                ImageUrl = "https://www.alleycat.org/wp-content/uploads/2019/03/FELV-cat.jpg",
                LocationId = 2,
                CategoryId = 2,
                BreedId = 2
            },
            new Pet
            {
                Id = 3,
                Name = "Parrot 1",
                Age = 2,
                Description = "Some description about parrot 1.",
                ImageUrl = "https://i.natgeofe.com/n/e3ae5fbf-ddc9-4b18-8c75-81d2daf962c1/3948225.jpg",
                LocationId = 3,
                CategoryId = 3,
                BreedId = 3
            },
            new Pet
            {
                Id = 4,
                Name = "Rodent 1",
                Age = 1,
                Description = "Some description about rodent 1.",
                ImageUrl = "https://www.bluecross.org.uk/sites/default/files/d8/assets/images/114895lpr.jpg",
                LocationId = 4,
                CategoryId = 4,
                BreedId = 4
            });
    }
}