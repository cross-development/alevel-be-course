using Microsoft.EntityFrameworkCore;
using HW_4_6.Data;
using HW_4_6.Models;
using HW_4_6.Repositories.Abstractions;

namespace HW_4_6.Repositories;

/// <summary>
/// Location repository.
/// </summary>
public sealed class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="LocationRepository"/> class.
    /// </summary>
    /// <param name="context">The instance of the <see cref="ApplicationDbContext"/> class.</param>
    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Used to get all location entries from the database.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ICollection<Location>> GetAllAsync()
    {
        return await _context.Locations.Include(location => location.Pets).ToListAsync();
    }

    /// <summary>
    /// Used to get one location entry by id from the database.
    /// </summary>
    /// <param name="id">Location id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Location> GetByIdAsync(int id)
    {
        return (await _context.Locations
            .AsNoTracking()
            .Where(location => location.Id == id)
            .FirstOrDefaultAsync())!;
    }

    /// <summary>
    /// Used to create location entry in the database.
    /// </summary>
    /// <param name="entity">Location entity to create a database entry.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> CreateAsync(Location entity)
    {
        await _context.AddAsync(entity);

        return await SaveAsync();
    }

    /// <summary>
    /// Used to update location entry in the database.
    /// </summary>
    /// <param name="entity">Location entity to update a database entry.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> UpdateAsync(Location entity)
    {
        _context.Update(entity);

        return await SaveAsync();
    }

    /// <summary>
    /// Used to delete location entry from the database.
    /// </summary>
    /// <param name="entity">Location entity to update a database entry.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> DeleteAsync(Location entity)
    {
        _context.Remove(entity);

        return await SaveAsync();
    }

    /// <summary>
    /// Used to save changes in the database.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> SaveAsync()
    {
        int saved = await _context.SaveChangesAsync();

        return saved > 0;
    }
}