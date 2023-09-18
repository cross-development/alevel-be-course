using HW_4_6.Models;

namespace HW_4_6.Dto;

/// <summary>
/// Pet list DTO.
/// </summary>
public sealed class PetListDto : PetDto
{
    /// <summary>
    /// Gets or sets navigation property for a location table.
    /// </summary>
    public Location Location { get; set; }

    /// <summary>
    /// Gets or sets navigation property for a category table.
    /// </summary>
    public Category Category { get; set; }

    /// <summary>
    /// Gets or sets navigation property for a breed table.
    /// </summary>
    public Breed Breed { get; set; }
}