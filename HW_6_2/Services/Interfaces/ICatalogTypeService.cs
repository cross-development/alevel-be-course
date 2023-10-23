using HW_6_2.Models.DTOs;
using HW_6_2.Models.Requests;
using HW_6_2.Models.Responses;

namespace HW_6_2.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<PaginatedResponse<CatalogTypeDto>> GetCatalogTypesAsync(PaginatedRequest request);
    Task<CatalogTypeDto> GetCatalogTypeByIdAsync(int id);
    Task<int?> AddCatalogTypeAsync(AddTypeRequest request);
    Task<bool> DeleteCatalogTypeAsync(CatalogTypeDto catalogTypeDto);
}