using Microsoft.EntityFrameworkCore;
using HW_6_2.Data;
using HW_6_2.Data.Entities;
using HW_6_2.Data.Interfaces;
using HW_6_2.Models.Common;
using HW_6_2.Models.Requests;
using HW_6_2.Repositories.Interfaces;

namespace HW_6_2.Repositories;

public sealed class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogBrandRepository(IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.ApplicationDbContext;
    }

    public async Task<PaginatedData<CatalogBrand>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogBrands.LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogBrands
            .OrderBy(brand => brand.Brand)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedData<CatalogBrand> { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<CatalogBrand> GetByIdAsync(int id)
    {
        var item = await _dbContext.CatalogBrands
            .Include(brand => brand.CatalogItems)
            .FirstOrDefaultAsync(brand => brand.Id == id);

        return item;
    }

    public async Task<int?> AddAsync(AddBrandRequest request)
    {
        var catalogBrand = new CatalogBrand { Brand = request.Brand };

        var item = await _dbContext.AddAsync(catalogBrand);

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