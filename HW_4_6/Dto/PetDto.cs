namespace HW_4_6.Dto;

/// <summary>
/// Pet DTO.
/// </summary>
public class PetDto
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
}