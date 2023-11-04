using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Interfaces;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public sealed class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogBrandRepository(IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.ApplicationDbContext;
    }

    public async Task<IEnumerable<CatalogBrand>> GetAllAsync()
    {
        var itemsOnPage = await _dbContext.CatalogBrands
            .OrderBy(brand => brand.Brand)
            .ToListAsync();

        return itemsOnPage;
    }

    public async Task<CatalogBrand> GetByIdAsync(int id)
    {
        var item = await _dbContext.CatalogBrands
            .Include(brand => brand.CatalogItems)
            .FirstOrDefaultAsync(brand => brand.Id == id);

        return item;
    }

    public async Task<CatalogBrand> FindOneAsync(int id)
    {
        var item = await _dbContext.CatalogBrands.FindAsync(id);

        return item;
    }

    public async Task<int?> AddAsync(CatalogBrand catalogBrand)
    {
        var item = await _dbContext.AddAsync(catalogBrand);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> UpdateAsync(CatalogBrand catalogBrand)
    {
        var item = _dbContext.CatalogBrands.Update(catalogBrand);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<bool> DeleteAsync(CatalogBrand catalogBrand)
    {
        _dbContext.Remove(catalogBrand);

        var result = await _dbContext.SaveChangesAsync() > 0;

        return result;
    }
}