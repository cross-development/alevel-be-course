using HW_6_3.Host.Data.Entities;
using HW_6_3.Host.Models.DTOs;
using HW_6_3.Host.Models.Requests;
using HW_6_3.Host.Models.Responses;

namespace HW_6_3.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<PaginatedResponse<CatalogTypeDto>> GetCatalogTypesAsync(PaginatedRequest request);
    Task<CatalogTypeDto> GetCatalogTypeByIdAsync(int id);
    Task<CatalogType> FindCatalogTypeAsync(int id);
    Task<int?> AddCatalogTypeAsync(AddTypeRequest request);
    Task<int?> UpdateCatalogTypeAsync(UpdateTypeRequest request, CatalogType catalogType);
    Task<bool> DeleteCatalogTypeAsync(CatalogType catalogType);
}