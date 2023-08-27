using HW_4_1.Configs;
using HW_4_1.Dto.Responses.Common;
using HW_4_1.Dto.Responses.User;
using HW_4_1.Interfaces;
using HW_4_1.Models;
using Microsoft.Extensions.Options;

namespace HW_4_1.Services;

/// <summary>
/// User service.
/// </summary>
public sealed class UserService : IUserService
{
    private readonly IHttpClientService _httpClientService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="httpClientService">The implementation of the <see cref="IHttpClientService"/> interface.</param>
    public UserService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    /// <summary>
    /// Get user by id.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<SingleResponse<User>> GetUserById(int userId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<CollectionResponse<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create user.
    /// </summary>
    /// <param name="name">User name.</param>
    /// <param name="job">User position.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<CreateUserResponse> CreateUser(string name, string job)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update user.
    /// </summary>
    /// <param name="id">User id.</param>
    /// <param name="name">User name.</param>
    /// <param name="job">User position.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<UpdateUserResponse> UpdateUser(int id, string name, string job)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task DeleteUser(int userId)
    {
        throw new NotImplementedException();
    }
}