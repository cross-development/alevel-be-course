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

    public async Task<PaginatedData<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems.LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(item => item.CatalogBrand)
            .Include(item => item.CatalogType)
            .OrderBy(item => item.Name)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedData<CatalogItem> { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> AddAsync(AddItemRequest item)
    {
        var newItem = await _dbContext.AddAsync(new CatalogItem
        {
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            PictureFileName = item.PictureFileName,
            AvailableStock = item.AvailableStock,
            CatalogBrandId = item.CatalogBrandId,
            CatalogTypeId = item.CatalogTypeId
        });

        await _dbContext.SaveChangesAsync();

        return newItem.Entity.Id;
    }
}