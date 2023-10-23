using AutoMapper;
using HW_6_2.Data;
using HW_6_2.Data.Entities;
using HW_6_2.Data.Interfaces;
using HW_6_2.Models.DTOs;
using HW_6_2.Models.Requests;
using HW_6_2.Models.Responses;
using HW_6_2.Repositories.Interfaces;
using HW_6_2.Services.Interfaces;

namespace HW_6_2.Services;

public sealed class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly IMapper _mapper;

    public CatalogBrandService(
        IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<CatalogBrandDto>> GetCatalogBrandsAsync(PaginatedRequest request)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var pageIndex = request.PageIndex;
            var pageSize = request.PageSize;

            var result = await _catalogBrandRepository.GetByPageAsync(pageIndex, pageSize);

            return new PaginatedResponse<CatalogBrandDto>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = result.TotalCount,
                Data = result.Data.Select(brand => _mapper.Map<CatalogBrandDto>(brand)).ToList()
            };
        });
    }

    public async Task<CatalogBrandDto> GetCatalogBrandByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogBrandRepository.GetByIdAsync(id);

            return _mapper.Map<CatalogBrandDto>(item);
        });
    }

    public async Task<int?> AddCatalogBrandAsync(AddBrandRequest request)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.AddAsync(request));
    }

    public async Task<bool> DeleteCatalogBrandAsync(CatalogBrandDto catalogBrandDto)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var catalogBrand = _mapper.Map<CatalogBrand>(catalogBrandDto);

            return await _catalogBrandRepository.DeleteAsync(catalogBrand);
        });
    }
}