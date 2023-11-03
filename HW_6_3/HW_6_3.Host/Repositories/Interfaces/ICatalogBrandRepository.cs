using HW_6_3.Host.Data.Entities;
using HW_6_3.Host.Models.Common;

namespace HW_6_3.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<PaginatedData<CatalogBrand>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogBrand> GetByIdAsync(int id);
    Task<CatalogBrand> FindOneAsync(int id);
    Task<int?> AddAsync(CatalogBrand catalogBrand);
    Task<int?> UpdateAsync(CatalogBrand catalogBrand);
    Task<bool> DeleteAsync(CatalogBrand catalogBrand);
}