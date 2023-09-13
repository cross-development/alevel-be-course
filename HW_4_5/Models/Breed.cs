namespace HW_4_5.Models;

/// <summary>
/// Breed model.
/// </summary>
public class Breed
{
    /// <summary>
    /// Gets or sets breed id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets breed name.
    /// </summary>
    public string BreedName { get; set; }

    /// <summary>
    /// Gets or sets pets in a breed.
    /// </summary>
    public ICollection<Pet> Pets { get; set; }

    /// <summary>
    /// Gets or sets category id for a breed.
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets navigation property for a category table.
    /// </summary>
    public Category Category { get; set; }
}