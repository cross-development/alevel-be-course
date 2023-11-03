using HW_6_3.Host.Data.Entities;
using HW_6_3.Host.Models.DTOs;
using HW_6_3.Host.Models.Requests;
using HW_6_3.Host.Models.Responses;

namespace HW_6_3.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<PaginatedResponse<CatalogBrandDto>> GetCatalogBrandsAsync(PaginatedRequest request);
    Task<CatalogBrandDto> GetCatalogBrandByIdAsync(int id);
    Task<CatalogBrand> FindCatalogBrandAsync(int id);
    Task<int?> AddCatalogBrandAsync(AddBrandRequest request);
    Task<int?> UpdateCatalogBrandAsync(UpdateBrandRequest request, CatalogBrand catalogBrand);
    Task<bool> DeleteCatalogBrandAsync(CatalogBrand catalogBrand);
}