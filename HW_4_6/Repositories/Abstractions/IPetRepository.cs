using HW_4_6.Models;

namespace HW_4_6.Repositories.Abstractions;

/// <summary>
/// Pet repository interface.
/// </summary>
public interface IPetRepository : IBaseRepository<Pet>
{
    /// <summary>
    /// Used to get all unique breeds for pets in certain location and start from certain age.
    /// </summary>
    /// <param name="age">Pet age.</param>
    /// <param name="locationId">Location id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<ICollection<CategoryBreed>> GetUniqueBreedsInCategory(int age, int locationId);
}