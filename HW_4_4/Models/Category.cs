namespace HW_4_4.Models;

/// <summary>
/// Category model.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets or sets category id.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets category name.
    /// </summary>
    public required string CategoryName { get; set; }

    /// <summary>
    /// Gets or sets pet in a category.
    /// </summary>
    public required ICollection<Pet> Pets { get; set; }

    /// <summary>
    /// Gets or sets breeds in a category.
    /// </summary>
    public required ICollection<Breed> Breeds { get; set; }
}