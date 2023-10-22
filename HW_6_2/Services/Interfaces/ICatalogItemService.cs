using HW_6_2.Models.Requests;

namespace HW_6_2.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> AddAsync(AddItemRequest item);
}