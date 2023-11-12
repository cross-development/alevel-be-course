using Basket.Host.Models.Responses;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public sealed class BasketService : IBasketService
{
    private readonly ICacheService _cacheService;

    public BasketService(ICacheService cacheService, ILogger<BasketService> logger)
    {
        _cacheService = cacheService;
    }

    public async Task<bool> AddItemAsync(string userId, string data)
    {
        return await _cacheService.AddOrUpdateAsync(userId, data);
    }

    public async Task<GetBasketResponse> GetBasketAsync(string userId)
    {
        var result = await _cacheService.GetAsync<string>(userId);

        return new GetBasketResponse { Data = result };
    }
}