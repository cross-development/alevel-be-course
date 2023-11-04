using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<IEnumerable<CatalogType>> GetAllAsync();

    Task<CatalogType> GetByIdAsync(int id);

    Task<CatalogType> FindOneAsync(int id);

    Task<int?> AddAsync(CatalogType catalogType);

    Task<int?> UpdateAsync(CatalogType catalogType);

    Task<bool> DeleteAsync(CatalogType catalogType);
}