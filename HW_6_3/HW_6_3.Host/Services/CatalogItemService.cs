using AutoMapper;
using HW_6_3.Host.Data;
using HW_6_3.Host.Data.Entities;
using HW_6_3.Host.Data.Interfaces;
using HW_6_3.Host.Models.DTOs;
using HW_6_3.Host.Models.Requests;
using HW_6_3.Host.Models.Responses;
using HW_6_3.Host.Services.Interfaces;
using HW_6_3.Host.Repositories.Interfaces;

namespace HW_6_3.Host.Services;

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
            var brandId = request.BrandId;
            var typeId = request.TypeId;

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

    public async Task<CatalogItem> FindCatalogItemAsync(int id)
    {
        return await ExecuteSafeAsync(() => _catalogItemRepository.FindOneAsync(id));
    }

    public async Task<int?> AddCatalogItemAsync(AddItemRequest request)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var catalogItem = _mapper.Map<CatalogItem>(request);

            return await _catalogItemRepository.AddAsync(catalogItem);
        });
    }

    public async Task<int?> UpdateCatalogItemAsync(UpdateItemRequest request, CatalogItem catalogItem)
    {
        return await ExecuteSafeAsync(async () =>
        {
            catalogItem.Name = request.Name ?? catalogItem.Name;
            catalogItem.Description = request.Description ?? catalogItem.Description;
            catalogItem.Price = request.Price ?? catalogItem.Price;
            catalogItem.AvailableStock = request.AvailableStock ?? catalogItem.AvailableStock;
            catalogItem.CatalogTypeId = request.CatalogTypeId ?? catalogItem.CatalogTypeId;
            catalogItem.CatalogBrandId = request.CatalogBrandId ?? catalogItem.CatalogBrandId;
            catalogItem.PictureFileName = request.PictureFileName ?? catalogItem.PictureFileName;

            return await _catalogItemRepository.UpdateAsync(catalogItem);
        });
    }

    public async Task<bool> DeleteCatalogItemAsync(CatalogItem catalogItem)
    {
        return await ExecuteSafeAsync(() => _catalogItemRepository.DeleteAsync(catalogItem));
    }
}