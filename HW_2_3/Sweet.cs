using HW_2_3.Interfaces;

namespace HW_2_3;

/// <summary>
/// Base class for other sweets.
/// </summary>
public abstract class Sweet : IGiftItem
{
    /// <summary>
    /// Gets or sets the name of a sweet.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the price of a sweet.
    /// </summary>
    public required double Price { get; set; }

    /// <summary>
    /// Gets or sets of sets the weight of a sweet.
    /// </summary>
    public required double Weight { get; set; }

    /// <summary>
    /// Gets some description of a sweet.
    /// </summary>
    /// <returns>A description of a sweet.</returns>
    public abstract string GetDescription();
}
