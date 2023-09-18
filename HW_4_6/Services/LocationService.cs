using AutoMapper;
using HW_4_6.Dto;
using HW_4_6.Models;
using HW_4_6.Repositories.Abstractions;
using HW_4_6.Services.Abstractions;

namespace HW_4_6.Services;

/// <summary>
/// Location service.
/// </summary>
public sealed class LocationService : ILocationService
{
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationService"/> class.
    /// </summary>
    /// <param name="locationRepository">An implementation of the <see cref="ILocationRepository"/> interface.</param>
    /// <param name="mapper">An implementation of the <see cref="IMapper"/> interface.</param>
    public LocationService(ILocationRepository locationRepository, IMapper mapper)
    {
        _locationRepository = locationRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Used to get all locations.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ICollection<LocationListDto>> GetAllLocationsAsync()
    {
        var locations = await _locationRepository.GetAllAsync();

        var locationsMap = _mapper.Map<ICollection<LocationListDto>>(locations);

        return locationsMap;
    }

    /// <summary>
    /// Used to get one location.
    /// </summary>
    /// <param name="id">Location id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<LocationDto> GetLocationById(int id)
    {
        var location = await _locationRepository.GetByIdAsync(id);

        var locationMap = _mapper.Map<LocationDto>(location);

        return locationMap;
    }

    /// <summary>
    ///  Used to create location.
    /// </summary>
    /// <param name="locationDto">Location to create <see cref="LocationDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> CreateLocation(LocationDto locationDto)
    {
        var locations = await _locationRepository.GetAllAsync();

        var fountLocation = locations
            .FirstOrDefault(location => location.LocationName.Trim().ToUpper() == locationDto.LocationName.Trim().ToUpper());

        if (fountLocation != null)
        {
            Console.WriteLine("Location already exists");
            return false;
        }

        var locationMap = _mapper.Map<Location>(locationDto);

        var isLocationCreated = await _locationRepository.CreateAsync(locationMap);

        if (!isLocationCreated)
        {
            Console.WriteLine("Something went wrong while saving the location");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Used to update location.
    /// </summary>
    /// <param name="locationDto">Location to update <see cref="LocationDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> UpdateLocation(LocationDto locationDto)
    {
        var location = await _locationRepository.GetByIdAsync(locationDto.Id);

        if (location == null)
        {
            Console.WriteLine("Location not found");
            return false;
        }

        var locationMap = _mapper.Map<Location>(locationDto);

        var isLocationUpdated = await _locationRepository.UpdateAsync(locationMap);

        if (!isLocationUpdated)
        {
            Console.WriteLine("Something went wrong while updating the location");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Used to delete location.
    /// </summary>
    /// <param name="id">Location id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> DeleteLocation(int id)
    {
        var location = await _locationRepository.GetByIdAsync(id);

        if (location == null)
        {
            Console.WriteLine("Location not found");
            return false;
        }

        var isLocationDeleted = await _locationRepository.DeleteAsync(location);

        if (!isLocationDeleted)
        {
            Console.WriteLine("Something went wrong while deleting the location");
            return false;
        }

        return true;
    }
}