using AutoMapper;
using HW_6_3.Host.Data;
using HW_6_3.Host.Data.Entities;
using HW_6_3.Host.Data.Interfaces;
using HW_6_3.Host.Models.DTOs;
using HW_6_3.Host.Models.Requests;
using HW_6_3.Host.Models.Responses;
using HW_6_3.Host.Repositories.Interfaces;
using HW_6_3.Host.Services.Interfaces;

namespace HW_6_3.Host.Services;

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

    public async Task<CatalogBrand> FindCatalogBrandAsync(int id)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.FindOneAsync(id));
    }

    public async Task<int?> AddCatalogBrandAsync(AddBrandRequest request)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var catalogBrand = _mapper.Map<CatalogBrand>(request);

            return await _catalogBrandRepository.AddAsync(catalogBrand);
        });
    }

    public async Task<int?> UpdateCatalogBrandAsync(UpdateBrandRequest request, CatalogBrand catalogBrand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            catalogBrand.Brand = request.Brand ?? catalogBrand.Brand;

            return await _catalogBrandRepository.UpdateAsync(catalogBrand);
        });
    }

    public async Task<bool> DeleteCatalogBrandAsync(CatalogBrand catalogBrand)
    {
        return await ExecuteSafeAsync(() => _catalogBrandRepository.DeleteAsync(catalogBrand));
    }
}