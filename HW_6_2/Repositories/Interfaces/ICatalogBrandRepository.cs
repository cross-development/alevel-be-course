using HW_6_2.Data.Entities;
using HW_6_2.Models.Common;
using HW_6_2.Models.Requests;

namespace HW_6_2.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<PaginatedData<CatalogBrand>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogBrand> GetByIdAsync(int id);
    Task<int?> AddAsync(AddBrandRequest request);
    Task<bool> DeleteAsync(CatalogBrand catalogBrand);
}