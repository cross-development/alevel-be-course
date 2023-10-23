using AutoMapper;
using HW_6_2.Data;
using HW_6_2.Data.Entities;
using HW_6_2.Data.Interfaces;
using HW_6_2.Models.DTOs;
using HW_6_2.Models.Requests;
using HW_6_2.Models.Responses;
using HW_6_2.Services.Interfaces;
using HW_6_2.Repositories.Interfaces;

namespace HW_6_2.Services;

public sealed class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<CatalogItemDto>> GetCatalogItemsAsync(PaginatedFilterRequest request)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var pageIndex = request.PageIndex;
            var pageSize = request.PageSize;
            var brandId = request?.BrandId;
            var typeId = request?.TypeId;

            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize, brandId, typeId);

            return new PaginatedResponse<CatalogItemDto>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = result.TotalCount,
                Data = result.Data.Select(item => _mapper.Map<CatalogItemDto>(item)).ToList()
            };
        });
    }

    public async Task<CatalogItemDto> GetCatalogItemByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogItemRepository.GetByIdAsync(id);

            return _mapper.Map<CatalogItemDto>(item);
        });
    }

    public async Task<int?> AddCatalogItemAsync(AddItemRequest request)
    {
        return await ExecuteSafeAsync(() => _catalogItemRepository.AddAsync(request));
    }

    public async Task<bool> DeleteCatalogItemAsync(CatalogItemDto catalogItemDto)
    {
        var catalogBrand = _mapper.Map<CatalogItem>(catalogItemDto);

        return await _catalogItemRepository.DeleteAsync(catalogBrand);
    }
}