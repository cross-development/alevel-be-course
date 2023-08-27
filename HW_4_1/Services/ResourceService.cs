using HW_4_1.Dto.Responses.Common;
using HW_4_1.Interfaces;
using HW_4_1.Models;

namespace HW_4_1.Services;

/// <summary>
/// Resource service.
/// </summary>
public sealed class ResourceService : IResourceService
{
    private readonly IHttpClientService _httpClientService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceService"/> class.
    /// </summary>
    /// <param name="httpClientService">The implementation of the <see cref="IHttpClientService"/> interface.</param>
    public ResourceService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    /// <summary>
    /// Get some resource by id.
    /// </summary>
    /// <param name="resourceId">Resource id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<SingleResponse<Resource>> GetResourceById(int resourceId)
    {
        var result = await _httpClientService.SendAsync<SingleResponse<Resource>>($"unknown/{resourceId}", HttpMethod.Get);

        return result;
    }

    /// <summary>
    /// Get all resources.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<CollectionResponse<Resource>> GetAllResources()
    {
        var result = await _httpClientService.SendAsync<CollectionResponse<Resource>>("unknown", HttpMethod.Get);

        return result;
    }
}