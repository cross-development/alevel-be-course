using HW_6_2.Data.Entities;
using HW_6_2.Models.Common;
using HW_6_2.Models.Requests;

namespace HW_6_2.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedData<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<int?> AddAsync(AddItemRequest item);
}