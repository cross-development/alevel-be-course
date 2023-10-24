using HW_6_2.Data.Entities;
using HW_6_2.Models.DTOs;
using HW_6_2.Models.Requests;
using HW_6_2.Models.Responses;

namespace HW_6_2.Services.Interfaces;

public interface ICatalogItemService
{
    Task<PaginatedResponse<CatalogItemDto>> GetCatalogItemsAsync(PaginatedFilterRequest request);
    Task<CatalogItemDto> GetCatalogItemByIdAsync(int id);
    Task<CatalogItem> FindCatalogItemAsync(int id);
    Task<int?> AddCatalogItemAsync(AddItemRequest request);
    Task<int?> UpdateCatalogItemAsync(UpdateItemRequest request, CatalogItem catalogItem);
    Task<bool> DeleteCatalogItemAsync(CatalogItem catalogItem);
}