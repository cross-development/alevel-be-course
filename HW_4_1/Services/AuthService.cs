using HW_4_1.Dto;
using HW_4_1.Dto.Responses.Auth;
using HW_4_1.Interfaces;

namespace HW_4_1.Services;

/// <summary>
/// Auth service.
/// </summary>
public sealed class AuthService : IAuthService
{
    private readonly IHttpClientService _httpClientService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// </summary>
    /// <param name="httpClientService">The implementation of the <see cref="IHttpClientService"/> interface.</param>
    public AuthService(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    /// <summary>
    /// Login user to the system.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<LoginResponse> Login(string username, string password)
    {
        var body = new AuthDto { Email = username, Password = password };

        var result = _httpClientService.SendAsync<LoginResponse>("login", HttpMethod.Post, body);

        return result;
    }

    /// <summary>
    /// Register user.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<RegisterResponse> Register(string username, string password)
    {
        var body = new AuthDto { Email = username, Password = password };

        var result = _httpClientService.SendAsync<RegisterResponse>("register", HttpMethod.Post, body);

        return result;
    }
}