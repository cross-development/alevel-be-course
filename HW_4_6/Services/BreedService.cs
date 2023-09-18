using AutoMapper;
using HW_4_6.Dto;
using HW_4_6.Models;
using HW_4_6.Repositories.Abstractions;
using HW_4_6.Services.Abstractions;

namespace HW_4_6.Services;

/// <summary>
/// Breed service.
/// </summary>
public sealed class BreedService : IBreedService
{
    private readonly IBreedRepository _breedRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="BreedService"/> class.
    /// </summary>
    /// <param name="breedRepository">An implementation of the <see cref="IBreedRepository"/> interface.</param>
    /// <param name="categoryRepository">An implementation of the <see cref="ICategoryRepository"/> interface.</param>
    /// <param name="mapper">An implementation of the <see cref="IMapper"/> interface.</param>
    public BreedService(IBreedRepository breedRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _breedRepository = breedRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Used to get all breeds.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ICollection<BreedListDto>> GetAllBreedsAsync()
    {
        var breeds = await _breedRepository.GetAllAsync();

        var breedsMap = _mapper.Map<ICollection<BreedListDto>>(breeds);

        return breedsMap;
    }

    /// <summary>
    /// Used to get one breed.
    /// </summary>
    /// <param name="id">Breed id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<BreedDto> GetBreedById(int id)
    {
        var breed = await _breedRepository.GetByIdAsync(id);

        var breedMap = _mapper.Map<BreedDto>(breed);

        return breedMap;
    }

    /// <summary>
    ///  Used to create breed.
    /// </summary>
    /// <param name="categoryId">Category id.</param>
    /// <param name="breedDto">Breed to create <see cref="BreedDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> CreateBreed(int categoryId, BreedDto breedDto)
    {
        var breeds = await _breedRepository.GetAllAsync();

        var foundBreed = breeds
            .FirstOrDefault(breed => breed.BreedName.Trim().ToUpper() == breedDto.BreedName.Trim().ToUpper());

        if (foundBreed != null)
        {
            Console.WriteLine("Breed already exists");
            return false;
        }

        var category = await _categoryRepository.GetByIdAsync(categoryId);

        if (category == null)
        {
            Console.WriteLine("Category not found");
            return false;
        }

        var breedMap = _mapper.Map<Breed>(breedDto);
        breedMap.CategoryId = category.Id;

        var isBreedCreated = await _breedRepository.CreateAsync(breedMap);

        if (!isBreedCreated)
        {
            Console.WriteLine("Something went wrong while saving the breed");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Used to update breed.
    /// </summary>
    /// <param name="categoryId">Category id.</param>
    /// <param name="breedDto">Breed to update <see cref="BreedDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> UpdateBreed(int categoryId, BreedDto breedDto)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryId);

        if (category == null)
        {
            Console.WriteLine("Category not found");
            return false;
        }

        var breed = await _breedRepository.GetByIdAsync(breedDto.Id);

        if (breed == null)
        {
            Console.WriteLine("Breed not found");
            return false;
        }

        var breedMap = _mapper.Map<Breed>(breedDto);
        breedMap.CategoryId = category.Id;

        var isBreedUpdated = await _breedRepository.UpdateAsync(breedMap);

        if (!isBreedUpdated)
        {
            Console.WriteLine("Something went wrong while updating the breed");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Used to delete breed.
    /// </summary>
    /// <param name="id">Breed id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> DeleteBreed(int id)
    {
        var breed = await _breedRepository.GetByIdAsync(id);

        if (breed == null)
        {
            Console.WriteLine("Breed not found");
            return false;
        }

        var isBreedDeleted = await _breedRepository.DeleteAsync(breed);

        if (!isBreedDeleted)
        {
            Console.WriteLine("Something went wrong while deleting the breed");
            return false;
        }

        return true;
    }
}