using AutoMapper;
using HW_4_5.Dto;
using HW_4_5.Models;
using HW_4_5.Repositories.Abstractions;
using HW_4_5.Services.Abstractions;

namespace HW_4_5.Services;

/// <summary>
/// Pet service.
/// </summary>
public sealed class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly IBreedRepository _breedRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="PetService"/> class.
    /// </summary>
    /// <param name="petRepository">An implementation of the <see cref="IPetRepository"/> interface.</param>
    /// <param name="breedRepository">An implementation of the <see cref="IBreedRepository"/> interface.</param>
    /// <param name="locationRepository">An implementation of the <see cref="ILocationRepository"/> interface.</param>
    /// <param name="categoryRepository">An implementation of the <see cref="ICategoryRepository"/> interface.</param>
    /// <param name="mapper">An implementation of the <see cref="IMapper"/> interface.</param>
    public PetService(
        IPetRepository petRepository,
        IBreedRepository breedRepository,
        ILocationRepository locationRepository,
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _petRepository = petRepository;
        _breedRepository = breedRepository;
        _locationRepository = locationRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Used to get all pets.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ICollection<PetListDto>> GetAllPetsAsync()
    {
        var pets = await _petRepository.GetAllAsync();

        var petsMap = _mapper.Map<ICollection<PetListDto>>(pets);

        return petsMap;
    }

    /// <summary>
    /// Used to get one pet.
    /// </summary>
    /// <param name="id">Pet id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<PetDto> GetPetById(int id)
    {
        var pet = await _petRepository.GetByIdAsync(id);

        var petMap = _mapper.Map<PetDto>(pet);

        return petMap;
    }

    /// <summary>
    ///  Used to create pet.
    /// </summary>
    /// <param name="breedId">Breed id.</param>
    /// <param name="locationId">Location id.</param>
    /// <param name="categoryId">Category id.</param>
    /// <param name="petDto">Pet to create <see cref="PetDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> CreatePet(int breedId, int locationId, int categoryId, PetDto petDto)
    {
        var pets = await _petRepository.GetAllAsync();

        var foundPet = pets
            .FirstOrDefault(pet => pet.Name.Trim().ToUpper() == petDto.Name.Trim().ToUpper());

        if (foundPet != null)
        {
            Console.WriteLine("Pet already exists");
            return false;
        }

        var category = await _categoryRepository.GetByIdAsync(categoryId);

        if (category == null)
        {
            Console.WriteLine("Category not found");
            return false;
        }

        var location = await _locationRepository.GetByIdAsync(locationId);

        if (location == null)
        {
            Console.WriteLine("Location not found");
            return false;
        }

        var breed = await _breedRepository.GetByIdAsync(breedId);

        if (breed == null)
        {
            Console.WriteLine("Breed not found");
            return false;
        }

        var petMap = _mapper.Map<Pet>(petDto);
        petMap.CategoryId = category.Id;
        petMap.LocationId = location.Id;
        petMap.BreedId = breed.Id;

        var isPetCreated = await _petRepository.CreateAsync(petMap);

        if (!isPetCreated)
        {
            Console.WriteLine("Something went wrong while saving the pet");
            return false;
        }

        return true;
    }
}