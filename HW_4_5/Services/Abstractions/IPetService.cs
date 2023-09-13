using HW_4_5.Dto;

namespace HW_4_5.Services.Abstractions;

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
    ///  Used to create pet.
    /// </summary>
    /// <param name="breedId">Breed id.</param>
    /// <param name="locationId">Location id.</param>
    /// <param name="categoryId">Category id.</param>
    /// <param name="petDto">Pet to create <see cref="PetDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> CreatePet(int breedId, int locationId, int categoryId, PetDto petDto);
}