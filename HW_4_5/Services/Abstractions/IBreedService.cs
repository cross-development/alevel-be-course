﻿using HW_4_5.Dto;

namespace HW_4_5.Services.Abstractions;

/// <summary>
/// Breed service interface.
/// </summary>
public interface IBreedService
{
    /// <summary>
    /// Used to get all breeds.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<ICollection<BreedListDto>> GetAllBreedsAsync();

    /// <summary>
    /// Used to get one breed.
    /// </summary>
    /// <param name="id">Breed id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<BreedDto> GetBreedById(int id);

    /// <summary>
    ///  Used to create breed.
    /// </summary>
    /// <param name="categoryId">Category id.</param>
    /// <param name="breedDto">Breed to create <see cref="BreedDto"/>.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> CreateBreed(int categoryId, BreedDto breedDto);
}