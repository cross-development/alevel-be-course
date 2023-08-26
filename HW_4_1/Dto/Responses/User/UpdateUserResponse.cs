namespace HW_4_1.Dto.Responses.User;

/// <summary>
/// Update user response.
/// </summary>
public sealed class UpdateUserResponse : BaseUserResponse
{
    /// <summary>
    /// Gets or sets time offset when the user was updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt { get; set; }
}