using Microsoft.EntityFrameworkCore;
using HW_4_6.Models;
using HW_4_6.Data.Configurations;

namespace HW_4_6.Data;

/// <summary>
/// Application database context.
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
    /// </summary>
    /// <param name="options">Database context options <see cref="DbContextOptions{ApplicationDbContext}"/>.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets pets.
    /// </summary>
    public DbSet<Pet> Pets { get; set; } = null!;

    /// <summary>
    /// Gets or sets breeds.
    /// </summary>
    public DbSet<Breed> Breeds { get; set; } = null!;

    /// <summary>
    /// Gets or sets locations.
    /// </summary>
    public DbSet<Location> Locations { get; set; } = null!;

    /// <summary>
    /// Gets or sets Categories.
    /// </summary>
    public DbSet<Category> Categories { get; set; } = null!;

    /// <summary>
    /// Used to apply configuration for the entities.
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetConfiguration());
        modelBuilder.ApplyConfiguration(new BreedConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}