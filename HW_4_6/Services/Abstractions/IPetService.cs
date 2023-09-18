using HW_4_6.Dto;

namespace HW_4_6.Services.Abstractions;

/// <summary>
/// Pet service interface.
/// </summary>
public interface IPetService
{
    /// <summary>
    /// Used to get all pets.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<ICollection<PetListDto>> GetAllPetsAsync();

    /// <summary>
    /// Used to get one pet.
    /// </summary>
    /// <param name="id">Pet id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<PetDto> GetPetById(int id);

    /// <summary>
    /// Used to get all unique breeds for pets in certain location and start from certain age.
    /// </summary>
    /// <param name="age">Pet age.</param>
    /// <param name="locationId">Location id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<ICollection<CategoryBreedDto>> GetUniqueBreedsInCategory(int age, int locationId);

    /// <summary>
    ///  Used to create pet.
    /// </summary>
    /// <param name="breedId">Breed id.</param>
    /// <param name="locationId">Location id.</param>
    /// <param name="categoryId">Category id.</param>
    /// <param name="petDto">Pet to create <see cref="PetDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> CreatePet(int breedId, int locationId, int categoryId, PetDto petDto);

    /// <summary>
    ///  Used to update pet.
    /// </summary>
    /// <param name="breedId">Breed id.</param>
    /// <param name="locationId">Location id.</param>
    /// <param name="categoryId">Category id.</param>
    /// <param name="petDto">Pet to update <see cref="PetDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> UpdatePet(int breedId, int locationId, int categoryId, PetDto petDto);

    /// <summary>
    /// Used to delete pet.
    /// </summary>
    /// <param name="id">Pet id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> DeletePet(int id);
}