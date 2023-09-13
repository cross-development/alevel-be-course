using HW_4_5.Dto;

namespace HW_4_5.Services.Abstractions;

/// <summary>
/// Location service interface.
/// </summary>
public interface ILocationService
{
    /// <summary>
    /// Used to get all locations.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<ICollection<LocationListDto>> GetAllLocationsAsync();

    /// <summary>
    /// Used to get one location.
    /// </summary>
    /// <param name="id">Location id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<LocationDto> GetLocationById(int id);

    /// <summary>
    ///  Used to create location.
    /// </summary>
    /// <param name="locationDto">Location to create <see cref="LocationDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> CreateLocation(LocationDto locationDto);
}