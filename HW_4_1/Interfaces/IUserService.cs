using HW_4_1.Dto.Responses.Common;
using HW_4_1.Dto.Responses.User;
using HW_4_1.Models;

namespace HW_4_1.Interfaces;

/// <summary>
/// User service interface.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Get user by id.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<SingleResponse<User>> GetUserById(int userId);

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<CollectionResponse<User>> GetAllUsers();

    /// <summary>
    /// Create user.
    /// </summary>
    /// <param name="name">User name.</param>
    /// <param name="job">User position.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<CreateUserResponse> CreateUser(string name, string job);

    /// <summary>
    /// Update user.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="name">User name.</param>
    /// <param name="job">User position.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<UpdateUserResponse> UpdateUser(int userId, string name, string job);

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<DeleteUserResponse> DeleteUser(int userId);
}