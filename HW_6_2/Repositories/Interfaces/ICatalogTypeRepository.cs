using HW_6_2.Data.Entities;
using HW_6_2.Models.Common;
using HW_6_2.Models.Requests;

namespace HW_6_2.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<PaginatedData<CatalogType>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogType> GetByIdAsync(int id);
    Task<int?> AddAsync(AddTypeRequest request);
    Task<bool> DeleteAsync(CatalogType catalogType);
}