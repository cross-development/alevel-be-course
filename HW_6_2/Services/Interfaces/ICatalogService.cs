using HW_6_2.Models.DTOs;
using HW_6_2.Models.Responses;

namespace HW_6_2.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageIndex, int pageSize);
}