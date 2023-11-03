using HW_6_3.Host.Data.Entities;
using HW_6_3.Host.Models.DTOs;
using HW_6_3.Host.Models.Requests;
using HW_6_3.Host.Models.Responses;

namespace HW_6_3.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<PaginatedResponse<CatalogItemDto>> GetCatalogItemsAsync(PaginatedFilterRequest request);
    Task<CatalogItemDto> GetCatalogItemByIdAsync(int id);
    Task<CatalogItem> FindCatalogItemAsync(int id);
    Task<int?> AddCatalogItemAsync(AddItemRequest request);
    Task<int?> UpdateCatalogItemAsync(UpdateItemRequest request, CatalogItem catalogItem);
    Task<bool> DeleteCatalogItemAsync(CatalogItem catalogItem);
}