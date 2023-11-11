using Microsoft.AspNetCore.Mvc.Rendering;
using EShop.DTOs.Requests;
using EShop.DTOs.Responses;

namespace EShop.Services.Interfaces;

public interface ICatalogService
{
    Task<CatalogResponseDto> GetCatalogItems(CatalogRequestDto catalogRequest);

    Task<IEnumerable<SelectListItem>> GetBrands();

    Task<IEnumerable<SelectListItem>> GetTypes();
}