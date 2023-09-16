namespace HW_4_6.Models;

/// <summary>
/// Location model.
/// </summary>
public class Location
{
    /// <summary>
    /// Gets or sets location id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets location name.
    /// </summary>
    public string LocationName { get; set; }

    /// <summary>
    /// Gets or sets pets in a location.
    /// </summary>
    public ICollection<Pet> Pets { get; set; }
}