using HW_4_1.Dto.Responses.Common;
using HW_4_1.Interfaces;
using HW_4_1.Models;

namespace HW_4_1.Services;

/// <summary>
/// Resource service.
/// </summary>
public sealed class ResourceService : IResourceService
{
    /// <summary>
    /// Get some resource by id.
    /// </summary>
    /// <param name="resourceId">Resource id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<SingleResponse<Resource>> GetResourceById(int resourceId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get all resources.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<CollectionResponse<Resource>> GetAllResources()
    {
        throw new NotImplementedException();
    }
}