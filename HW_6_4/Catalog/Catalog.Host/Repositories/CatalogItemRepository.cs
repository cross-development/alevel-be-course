using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Interfaces;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Common;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public sealed class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogItemRepository(IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.ApplicationDbContext;
    }

    public async Task<PaginatedData<CatalogItem>> GetByPageAsync(int page, int limit, int? brandId, int? typeId)
    {
        IQueryable<CatalogItem> query = _dbContext.CatalogItems;

        if (brandId != null)
        {
            query = query.Where(item => item.CatalogBrandId == brandId);
        }

        if (typeId != null)
        {
            query = query.Where(item => item.CatalogTypeId == typeId);
        }

        var totalItems = await query.CountAsync();

        var itemsOnPage = await query
            .OrderBy(item => item.Name)
            .Include(item => item.CatalogBrand)
            .Include(item => item.CatalogType)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();

        return new PaginatedData<CatalogItem> { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<CatalogItem> GetByIdAsync(int id)
    {
        var item = await _dbContext.CatalogItems
            .Include(item => item.CatalogBrand)
            .Include(item => item.CatalogType)
            .FirstOrDefaultAsync(item => item.Id == id);

        return item;
    }

    public async Task<CatalogItem> FindOneAsync(int id)
    {
        var item = await _dbContext.CatalogItems.FindAsync(id);

        return item;
    }

    public async Task<int?> AddAsync(CatalogItem catalogItem)
    {
        var item = await _dbContext.AddAsync(catalogItem);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> UpdateAsync(CatalogItem catalogItem)
    {
        var item = _dbContext.Update(catalogItem);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<bool> DeleteAsync(CatalogItem catalogItem)
    {
        _dbContext.Remove(catalogItem);

        var result = await _dbContext.SaveChangesAsync() > 0;

        return result;
    }
}