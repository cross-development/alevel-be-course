using Microsoft.EntityFrameworkCore;
using HW_6_2.Data;
using HW_6_2.Data.Entities;
using HW_6_2.Data.Interfaces;
using HW_6_2.Models.Common;
using HW_6_2.Models.Requests;
using HW_6_2.Repositories.Interfaces;

namespace HW_6_2.Repositories;

public sealed class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogItemRepository(IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.ApplicationDbContext;
    }

    public async Task<PaginatedData<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? brandId, int? typeId)
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

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .OrderBy(item => item.Name)
            .Include(item => item.CatalogBrand)
            .Include(item => item.CatalogType)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
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

    public async Task<int?> AddAsync(AddItemRequest request)
    {
        var catalogItem = new CatalogItem
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            PictureFileName = request.PictureFileName,
            AvailableStock = request.AvailableStock,
            CatalogBrandId = request.CatalogBrandId,
            CatalogTypeId = request.CatalogTypeId
        };

        var item = await _dbContext.AddAsync(catalogItem);

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