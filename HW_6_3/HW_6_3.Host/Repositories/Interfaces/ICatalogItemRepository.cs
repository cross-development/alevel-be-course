using HW_6_3.Host.Data.Entities;
using HW_6_3.Host.Models.Common;

namespace HW_6_3.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedData<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? brandId, int? typeId);
    Task<CatalogItem> GetByIdAsync(int id);
    Task<CatalogItem> FindOneAsync(int id);
    Task<int?> AddAsync(CatalogItem catalogItem);
    Task<int?> UpdateAsync(CatalogItem catalogItem);
    Task<bool> DeleteAsync(CatalogItem catalogItem);
}