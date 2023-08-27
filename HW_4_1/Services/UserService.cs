using HW_4_1.Dto;
using HW_4_1.Dto.Responses.Common;
using HW_4_1.Dto.Responses.User;
using HW_4_1.Interfaces;
using HW_4_1.Models;

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
    public async Task<SingleResponse<User>> GetUserById(int userId)
    {
        var result = await _httpClientService.SendAsync<SingleResponse<User>>($"users/{userId}", HttpMethod.Get);

        return result;
    }

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<CollectionResponse<User>> GetAllUsers()
    {
        var result = await _httpClientService.SendAsync<CollectionResponse<User>>("users", HttpMethod.Get);

        return result;
    }

    /// <summary>
    /// Create user.
    /// </summary>
    /// <param name="name">User name.</param>
    /// <param name="job">User position.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<CreateUserResponse> CreateUser(string name, string job)
    {
        var body = new UserDto { Name = name, Job = job };

        var result = await _httpClientService.SendAsync<CreateUserResponse>("users", HttpMethod.Post, body);

        return result;
    }

    /// <summary>
    /// Update user.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="name">User name.</param>
    /// <param name="job">User position.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<UpdateUserResponse> UpdateUser(int userId, string name, string job)
    {
        var body = new UserDto { Job = job, Name = name };

        var result = await _httpClientService.SendAsync<UpdateUserResponse>($"users/{userId}", HttpMethod.Put, body);

        return result;
    }

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<DeleteUserResponse> DeleteUser(int userId)
    {
        var result = await _httpClientService.SendAsync<DeleteUserResponse>($"users/{userId}", HttpMethod.Delete);

        return result;
    }
}