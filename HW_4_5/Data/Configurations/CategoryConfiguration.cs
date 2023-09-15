using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HW_4_5.Models;

namespace HW_4_5.Data.Configurations;

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
                CategoryName = "Dogs"
            },
            new Category
            {
                Id = 2,
                CategoryName = "Cats"
            },
            new Category
            {
                Id = 3,
                CategoryName = "Parrots"
            },
            new Category
            {
                Id = 4,
                CategoryName = "Rodents"
            });
    }
}