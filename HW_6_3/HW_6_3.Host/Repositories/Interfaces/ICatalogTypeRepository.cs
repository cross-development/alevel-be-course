using HW_6_3.Host.Data.Entities;
using HW_6_3.Host.Models.Common;

namespace HW_6_3.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<PaginatedData<CatalogType>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogType> GetByIdAsync(int id);
    Task<CatalogType> FindOneAsync(int id);
    Task<int?> AddAsync(CatalogType catalogType);
    Task<int?> UpdateAsync(CatalogType catalogType);
    Task<bool> DeleteAsync(CatalogType catalogType);
}