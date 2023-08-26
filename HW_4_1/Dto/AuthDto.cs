namespace HW_4_1.Dto;

/// <summary>
/// Auth DTO.
/// </summary>
public class AuthDto
{
    /// <summary>
    /// Gets or sets email.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets password.
    /// </summary>
    public required string Password { get; set; }
}