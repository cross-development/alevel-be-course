using Microsoft.EntityFrameworkCore;
using HW_4_5.Data;
using HW_4_5.Models;
using HW_4_5.Repositories.Abstractions;

namespace HW_4_5.Repositories;

/// <summary>
/// Category repository.
/// </summary>
public sealed class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="context">The instance of the <see cref="ApplicationDbContext"/> class.</param>
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Used to get all category entries from the database.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<ICollection<Category>> GetAllAsync()
    {
        return await _context.Categories.Include(category => category.Breeds).ToListAsync();
    }

    /// <summary>
    /// Used to get one category entry by id from the database.
    /// </summary>
    /// <param name="id">Category id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<Category> GetByIdAsync(int id)
    {
        return (await _context.Categories.Where(category => category.Id == id).FirstOrDefaultAsync())!;
    }

    /// <summary>
    /// Used to create category entry in the database.
    /// </summary>
    /// <param name="entity">Category entity to create a database entry.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<bool> CreateAsync(Category entity)
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