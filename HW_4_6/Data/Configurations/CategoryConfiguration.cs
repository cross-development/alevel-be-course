using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HW_4_6.Models;

namespace HW_4_6.Data.Configurations;

/// <summary>
/// Configurations for the category table.
/// </summary>
public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    /// <summary>
    /// Used to configure the entity of type <see cref="Category"/>.
    /// </summary>
    /// <param name="builder">The instance of <see cref="EntityTypeBuilder"/> class.</param>
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);
        builder.Property(category => category.Id).ValueGeneratedNever();
        builder.Property(category => category.CategoryName).IsRequired();

        builder.HasData(
            new Category
            {
                Id = 1,
                CategoryName = "Dogs",
                CategoryType = "Type 1"
            },
            new Category
            {
                Id = 2,
                CategoryName = "Cats",
                CategoryType = "Type 1"
            },
            new Category
            {
                Id = 3,
                CategoryName = "Parrots",
                CategoryType = "Type 2"
            },
            new Category
            {
                Id = 4,
                CategoryName = "Rodents",
                CategoryType = "Type 2"
            });
    }
}