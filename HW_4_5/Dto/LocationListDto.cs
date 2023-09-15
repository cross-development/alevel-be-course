using HW_4_5.Models;

namespace HW_4_5.Dto;

/// <summary>
/// Location list DTO.
/// </summary>
public class LocationListDto : LocationDto
{
    /// <summary>
    /// Gets or sets pets in a location.
    /// </summary>
    public ICollection<Pet> Pets { get; set; }
}