using Microsoft.EntityFrameworkCore;
using HW_4_5.Data;
using HW_4_5.Models;
using HW_4_5.Repositories.Abstractions;

namespace HW_4_5.Repositories;

/// <summary>
/// Breed repository.
/// </summary>
public sealed class BreedRepository : IBreedRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BreedRepository"/> class.
    /// </summary>
    /// <param name="context">The instance of the <see cref="ApplicationDbContext"/> class.</param>
    public BreedRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Used to get all breed entries from the database.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ICollection<Breed>> GetAllAsync()
    {
        return await _context.Breeds.Include(breed => breed.Category).ToListAsync();
    }

    /// <summary>
    /// Used to get one breed entry by id from the database.
    /// </summary>
    /// <param name="id">Breed id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Breed> GetByIdAsync(int id)
    {
        return (await _context.Breeds.Where(breed => breed.Id == id).FirstOrDefaultAsync())!;
    }

    /// <summary>
    /// Used to create breed entry in the database.
    /// </summary>
    /// <param name="entity">Breed entity to create a database entry.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> CreateAsync(Breed entity)
    {
        await _context.AddAsync(entity);

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