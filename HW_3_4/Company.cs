namespace HW_3_4;

/// <summary>
/// Company class.
/// </summary>
public class Company
{
    /// <summary>
    /// Gets or sets a company title.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets a company location.
    /// </summary>
    public required string Location { get; set; }

    /// <summary>
    /// Overrides base method.
    /// </summary>
    /// <returns>String representation of a company.</returns>
    public override string ToString()
    {
        return $"Company name: {Title}, location: {Location}";
    }
}