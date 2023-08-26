namespace HW_4_1.Dto.Responses.Auth;

/// <summary>
/// Login response.
/// </summary>
public sealed class LoginResponse
{
    /// <summary>
    /// Gets or sets token.
    /// </summary>
    public required string Token { get; set; }
}