namespace HW_4_5.Models;

/// <summary>
/// Category model.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets or sets category id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets category name.
    /// </summary>
    public string CategoryName { get; set; }

    /// <summary>
    /// Gets or sets category type.
    /// </summary>
    public string CategoryType { get; set; }

    /// <summary>
    /// Gets or sets pet in a category.
    /// </summary>
    public ICollection<Pet> Pets { get; set; }

    /// <summary>
    /// Gets or sets breeds in a category.
    /// </summary>
    public ICollection<Breed> Breeds { get; set; }
}