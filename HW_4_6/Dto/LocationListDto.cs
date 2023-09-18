using HW_4_6.Models;

namespace HW_4_6.Dto;

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