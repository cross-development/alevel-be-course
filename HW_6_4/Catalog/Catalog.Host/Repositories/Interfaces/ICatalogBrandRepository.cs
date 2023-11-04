using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<IEnumerable<CatalogBrand>> GetAllAsync();

    Task<CatalogBrand> GetByIdAsync(int id);

    Task<CatalogBrand> FindOneAsync(int id);

    Task<int?> AddAsync(CatalogBrand catalogBrand);

    Task<int?> UpdateAsync(CatalogBrand catalogBrand);

    Task<bool> DeleteAsync(CatalogBrand catalogBrand);
}