using HW_4_1.Dto.Responses.Auth;

namespace HW_4_1.Interfaces;

/// <summary>
/// Auth service interface.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Login user to the system.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<LoginResponse> Login(string username, string password);

    /// <summary>
    /// Register user.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<RegisterResponse> Register(string username, string password);
}