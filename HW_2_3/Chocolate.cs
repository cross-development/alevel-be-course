namespace HW_2_3;

/// <summary>
/// Chocolate class.
/// </summary>
public class Chocolate : Sweet
{
    /// <summary>
    /// Gets or sets a type of chocolate.
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// Gets a description of candy.
    /// </summary>
    /// <returns>A description of chocolate.</returns>
    public override string GetDescription()
    {
        return $"Candy: {Name}, Type: {Type}, Price: {Price}, Weight: {Weight}";
    }
}