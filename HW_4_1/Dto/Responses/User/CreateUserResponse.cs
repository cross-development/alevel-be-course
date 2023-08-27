namespace HW_4_1.Dto.Responses.User;

/// <summary>
/// Create user response.
/// </summary>
public sealed class CreateUserResponse : BaseUserResponse
{
    /// <summary>
    /// Gets or sets user id.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets time offset when the user was created.
    /// </summary>
    public required DateTimeOffset CreatedAt { get; set; }
}