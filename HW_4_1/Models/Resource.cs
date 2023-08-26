using Newtonsoft.Json;

namespace HW_4_1.Models;

/// <summary>
/// Resource model.
/// </summary>
public sealed class Resource
{
    /// <summary>
    /// Gets or sets resource id.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Gets or sets resource name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets resource year.
    /// </summary>
    public required int Year { get; set; }

    /// <summary>
    /// Gets or sets resource color.
    /// </summary>
    public required string Color { get; set; }

    /// <summary>
    /// Gets or sets resource pantone value.
    /// </summary>
    [JsonProperty("pantone_value")]
    public required string PantoneValue { get; set; }
}