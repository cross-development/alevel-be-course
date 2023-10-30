using HW_6_2.Data.Entities;
using HW_6_2.Models.DTOs;
using HW_6_2.Models.Requests;
using HW_6_2.Models.Responses;

namespace HW_6_2.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<PaginatedResponse<CatalogTypeDto>> GetCatalogTypesAsync(PaginatedRequest request);
    Task<CatalogTypeDto> GetCatalogTypeByIdAsync(int id);
    Task<CatalogType> FindCatalogTypeAsync(int id);
    Task<int?> AddCatalogTypeAsync(AddTypeRequest request);
    Task<int?> UpdateCatalogTypeAsync(UpdateTypeRequest request, CatalogType catalogType);
    Task<bool> DeleteCatalogTypeAsync(CatalogType catalogType);
}