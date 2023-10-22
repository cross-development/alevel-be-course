using HW_6_2.Data;
using HW_6_2.Data.Interfaces;
using HW_6_2.Models.Requests;
using HW_6_2.Services.Interfaces;
using HW_6_2.Repositories.Interfaces;

namespace HW_6_2.Services;

public sealed class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CatalogItemService(
        IApplicationDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
    }

    public async Task<int?> AddAsync(AddItemRequest item)
    {
        return await ExecuteSafeAsync(() => _catalogItemRepository.AddAsync(item));
    }
}