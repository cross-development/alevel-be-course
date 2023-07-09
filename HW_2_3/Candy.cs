namespace HW_2_3;

/// <summary>
/// Candy Class.
/// </summary>
public class Candy : Sweet
{
    /// <summary>
    /// Gets or sets a flavor of candy.
    /// </summary>
    public required string Flavor { get; set; }

    /// <summary>
    /// Gets a description of candy.
    /// </summary>
    /// <returns>A description of candy.</returns>
    public override string GetDescription()
    {
        return $"Candy: {Name}, Flavor: {Flavor}, Price: {Price}, Weight: {Weight}";
    }
}