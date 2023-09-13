using HW_4_5.Models;

namespace HW_4_5.Dto;

/// <summary>
/// Breed list DTO.
/// </summary>
public sealed class BreedListDto : BreedDto
{
    /// <summary>
    /// Gets or sets navigation property for a category table.
    /// </summary>
    public Category Category { get; set; }
}
