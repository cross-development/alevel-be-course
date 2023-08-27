using Newtonsoft.Json;

namespace HW_4_1.Models;

/// <summary>
/// User model.
/// </summary>
public sealed class User
{
    /// <summary>
    /// Gets or sets user id.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets user email.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets user first name.
    /// </summary>
    [JsonProperty("first_name")]
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets user last name.
    /// </summary>
    [JsonProperty("last_name")]
    public required string LastName { get; set; }

    /// <summary>
    /// Gets or sets user avatar.
    /// </summary>
    public required string Avatar { get; set; }
}