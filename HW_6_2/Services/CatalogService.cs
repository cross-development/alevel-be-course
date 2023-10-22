using AutoMapper;
using HW_6_2.Data;
using HW_6_2.Data.Interfaces;
using HW_6_2.Models.DTOs;
using HW_6_2.Models.Responses;
using HW_6_2.Repositories.Interfaces;
using HW_6_2.Services.Interfaces;

namespace HW_6_2.Services;

public sealed class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageIndex, int pageSize)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize);

            return new PaginatedResponse<CatalogItemDto>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = result.TotalCount,
                Data = result.Data.Select(item => _mapper.Map<CatalogItemDto>(item)).ToList(),
            };
        });
    }
}