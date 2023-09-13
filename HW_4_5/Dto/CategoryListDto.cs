using HW_4_5.Models;

namespace HW_4_5.Dto;

/// <summary>
/// Category list DTO.
/// </summary>
public sealed class CategoryListDto : CategoryDto
{
    /// <summary>
    /// Gets or sets breeds in a category.
    /// </summary>
    public ICollection<Breed> Breeds { get; set; }
}