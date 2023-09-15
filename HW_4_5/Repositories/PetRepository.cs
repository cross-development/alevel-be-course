using Microsoft.EntityFrameworkCore;
using HW_4_5.Data;
using HW_4_5.Models;
using HW_4_5.Repositories.Abstractions;

namespace HW_4_5.Repositories;

/// <summary>
/// Pet repository.
/// </summary>
public sealed class PetRepository : IPetRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="PetRepository"/> class.
    /// </summary>
    /// <param name="context">The instance of the <see cref="ApplicationDbContext"/> class.</param>
    public PetRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Used to get all pet entries from the database.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ICollection<Pet>> GetAllAsync()
    {
        return await _context.Pets
            .Include(pet => pet.Breed)
            .Include(pet => pet.Category)
            .Include(pet => pet.Location)
            .ToListAsync();
    }

    /// <summary>
    /// Used to get one pet entry by id from the database.
    /// </summary>
    /// <param name="id">Pet id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Pet> GetByIdAsync(int id)
    {
        return (await _context.Pets.Where(pet => pet.Id == id).FirstOrDefaultAsync())!;
    }

    /// <summary>
    /// Used to create pet entry in the database.
    /// </summary>
    /// <param name="entity">Pet entity to create a database entry.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> CreateAsync(Pet entity)
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