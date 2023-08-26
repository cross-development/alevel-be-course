namespace HW_4_1.Dto.Responses.Auth;

/// <summary>
/// Register response.
/// </summary>
public sealed class RegisterResponse
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets token.
    /// </summary>
    public required string Token { get; set; }
}