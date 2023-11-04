using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Interfaces;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public sealed class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogTypeRepository(IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.ApplicationDbContext;
    }

    public async Task<IEnumerable<CatalogType>> GetAllAsync()
    {
        var itemsOnPage = await _dbContext.CatalogTypes
            .OrderBy(type => type.Type)
            .ToListAsync();

        return itemsOnPage;
    }

    public async Task<CatalogType> GetByIdAsync(int id)
    {
        var item = await _dbContext.CatalogTypes
            .Include(type => type.CatalogItems)
            .FirstOrDefaultAsync(item => item.Id == id);
        
        return item;
    }

    public async Task<CatalogType> FindOneAsync(int id)
    {
        var item = await _dbContext.CatalogTypes.FindAsync(id);

        return item;
    }

    public async Task<int?> AddAsync(CatalogType catalogType)
    {
        var item = await _dbContext.AddAsync(catalogType);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> UpdateAsync(CatalogType catalogType)
    {
        var item = _dbContext.Update(catalogType);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<bool> DeleteAsync(CatalogType catalogType)
    {
        _dbContext.Remove(catalogType);

        var result = await _dbContext.SaveChangesAsync() > 0;

        return result;
    }
}