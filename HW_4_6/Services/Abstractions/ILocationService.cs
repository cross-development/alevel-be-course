using HW_4_6.Dto;

namespace HW_4_6.Services.Abstractions;

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

    /// <summary>
    /// Used to update location.
    /// </summary>
    /// <param name="locationDto">Location to update <see cref="LocationDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> UpdateLocation(LocationDto locationDto);

    /// <summary>
    /// Used to delete location.
    /// </summary>
    /// <param name="id">Location id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> DeleteLocation(int id);
}