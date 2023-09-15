namespace HW_4_5.Repositories.Abstractions;

/// <summary>
/// Base interface for all repositories.
/// </summary>
/// <typeparam name="T">The type returned from this method.</typeparam>
public interface IBaseRepository<T>
    where T : class
{
    /// <summary>
    /// Used to get all entries from the database.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<ICollection<T>> GetAllAsync();

    /// <summary>
    /// Used to get one entry by id from the database.
    /// </summary>
    /// <param name="id">Entry id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<T> GetByIdAsync(int id);

    /// <summary>
    /// Used to create some entry in the database.
    /// </summary>
    /// <param name="entity">Some entity to create a database entry.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> CreateAsync(T entity);

    /// <summary>
    /// Used to save changes in the database.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<bool> SaveAsync();
}