namespace HW_4_1.Dto.Responses.User;

/// <summary>
/// Base user response.
/// </summary>
public abstract class BaseUserResponse
{
    /// <summary>
    /// Gets or sets user name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets user job.
    /// </summary>
    public required string Job { get; set; }
}