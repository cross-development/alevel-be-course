namespace HW_2_3.Interfaces;

/// <summary>
/// Gift item interface.
/// </summary>
public interface IGiftItem
{
    /// <summary>
    /// Gets or sets the name of a sweet.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the price of a sweet.
    /// </summary>
    double Price { get; set; }

    /// <summary>
    /// Gets or sets of sets the weight of a sweet.
    /// </summary>
    double Weight { get; set; }

    /// <summary>
    /// Gets some description of a sweet.
    /// </summary>
    /// <returns>A description of a sweet.</returns>
    string GetDescription();
}
