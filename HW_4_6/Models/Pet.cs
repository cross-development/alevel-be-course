namespace HW_4_6.Models;

/// <summary>
/// Pet model.
/// </summary>
public class Pet
{
    /// <summary>
    /// Gets or sets pet id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets pet name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets pet age.
    /// </summary>
    public float Age { get; set; }

    /// <summary>
    /// Gets or sets pet description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets pet image.
    /// </summary>
    public string ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets location id for a pet.
    /// </summary>
    public int? LocationId { get; set; }

    /// <summary>
    /// Gets or sets navigation property for a location table.
    /// </summary>
    public Location Location { get; set; }

    /// <summary>
    /// Gets or sets category id for a pet.
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets navigation property for a category table.
    /// </summary>
    public Category Category { get; set; }

    /// <summary>
    /// Gets or sets breed id for a pet.
    /// </summary>
    public int? BreedId { get; set; }

    /// <summary>
    /// Gets or sets navigation property for a breed table.
    /// </summary>
    public Breed Breed { get; set; }
}