using HW_4_1.Dto.Responses.Auth;
using HW_4_1.Interfaces;

namespace HW_4_1.Services;

/// <summary>
/// Auth service.
/// </summary>
public sealed class AuthService : IAuthService
{
    /// <summary>
    /// Login user to the system.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<LoginResponse> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Register user.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<RegisterResponse> Register(string username, string password)
    {
        throw new NotImplementedException();
    }
}