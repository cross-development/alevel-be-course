using HW_4_6.Models;

namespace HW_4_6.Dto;

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