using HW_4_1.Dto.Responses.Common;
using HW_4_1.Models;

namespace HW_4_1.Interfaces;

/// <summary>
/// Resource service interface.
/// </summary>
public interface IResourceService
{
    /// <summary>
    /// Get some resource by id.
    /// </summary>
    /// <param name="resourceId">Resource id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<SingleResponse<Resource>> GetResourceById(int resourceId);

    /// <summary>
    /// Get all resources.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<CollectionResponse<Resource>> GetAllResources();
}