using HW_6_2.Models.DTOs;
using HW_6_2.Models.Requests;
using HW_6_2.Models.Responses;

namespace HW_6_2.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<PaginatedResponse<CatalogBrandDto>> GetCatalogBrandsAsync(PaginatedRequest request);
    Task<CatalogBrandDto> GetCatalogBrandByIdAsync(int id);
    Task<int?> AddCatalogBrandAsync(AddBrandRequest request);
    Task<bool> DeleteCatalogBrandAsync(CatalogBrandDto catalogBrandDto);
}