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

public sealed class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;

    public CatalogTypeService(
        IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<CatalogTypeDto>> GetCatalogTypesAsync(PaginatedRequest request)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var pageIndex = request.PageIndex;
            var pageSize = request.PageSize;

            var result = await _catalogTypeRepository.GetByPageAsync(pageIndex, pageSize);

            return new PaginatedResponse<CatalogTypeDto>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = result.TotalCount,
                Data = result.Data.Select(type => _mapper.Map<CatalogTypeDto>(type)).ToList()
            };
        });
    }

    public async Task<CatalogTypeDto> GetCatalogTypeByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogTypeRepository.GetByIdAsync(id);

            return _mapper.Map<CatalogTypeDto>(item);
        });
    }

    public async Task<int?> AddCatalogTypeAsync(AddTypeRequest request)
    {
        return await ExecuteSafeAsync(() => _catalogTypeRepository.AddAsync(request));
    }

    public async Task<bool> DeleteCatalogTypeAsync(CatalogTypeDto catalogTypeDto)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var catalogType = _mapper.Map<CatalogType>(catalogTypeDto);

            return await _catalogTypeRepository.DeleteAsync(catalogType);
        });
    }
}