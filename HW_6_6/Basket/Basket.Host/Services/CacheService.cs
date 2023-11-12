using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using Basket.Host.Configurations;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public sealed class CacheService : ICacheService
{
    private readonly ILogger<CacheService> _logger;
    private readonly RedisConfiguration _config;
    private readonly IRedisCacheConnectionService _redisCacheConnectionService;

    public CacheService(
        ILogger<CacheService> logger,
        IOptions<RedisConfiguration> config,
        IRedisCacheConnectionService redisCacheConnectionService)
    {
        _logger = logger;
        _config = config.Value;
        _redisCacheConnectionService = redisCacheConnectionService;
    }

    private IDatabase GetRedisDatabase() => _redisCacheConnectionService.Connection.GetDatabase();

    public async Task<T> GetAsync<T>(string key)
    {
        var redis = GetRedisDatabase();

        var serialized = await redis.StringGetAsync(key);

        var cachedData = serialized.HasValue ? JsonConvert.DeserializeObject<T>(serialized.ToString()) : default;

        _logger.LogInformation($"[CacheService: GetAsync] --> The cached data was received for the key: {key}");
        _logger.LogInformation($"[CacheService: GetAsync] --> The received cached data: {cachedData}");

        return cachedData;
    }

    public async Task<bool> AddOrUpdateAsync<T>(string key, T value)
    {
        var redis = GetRedisDatabase();

        var serialized = JsonConvert.SerializeObject(value);

        var isDataCached = await redis.StringSetAsync(key, serialized, _config.CacheTimeout);

        if (isDataCached)
        {
            _logger.LogInformation($"[CacheService: AddOrUpdateAsync] --> The data was cached for the key: {key}");
            _logger.LogInformation($"[CacheService: AddOrUpdateAsync] --> The cached data: {serialized}");
        }
        else
        {
            _logger.LogInformation($"[CacheService: AddOrUpdateAsync] --> The data was updated for the key: {key}");
            _logger.LogInformation($"[CacheService: AddOrUpdateAsync] --> The updated data: {serialized}");
        }

        return isDataCached;
    }
}
