using HW_6_2.Data.Entities;
using HW_6_2.Models.Common;
using HW_6_2.Models.Requests;

namespace HW_6_2.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedData<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? brandId, int? typeId);
    Task<CatalogItem> GetByIdAsync(int id);
    Task<int?> AddAsync(AddItemRequest request);
    Task<bool> DeleteAsync(CatalogItem catalogItem);
}