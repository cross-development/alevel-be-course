using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Common;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedData<CatalogItem>> GetByPageAsync(int page, int limit, int? brandId, int? typeId);

    Task<CatalogItem> GetByIdAsync(int id);

    Task<CatalogItem> FindOneAsync(int id);

    Task<int?> AddAsync(CatalogItem catalogItem);

    Task<int?> UpdateAsync(CatalogItem catalogItem);

    Task<bool> DeleteAsync(CatalogItem catalogItem);
}