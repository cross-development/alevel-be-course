namespace HW_2_3;

/// <summary>
/// Cookie Class.
/// </summary>
public class Cookie : Sweet
{
    /// <summary>
    /// Gets or sets a value indicating whether gets or sets a status of containing sugar.
    /// </summary>
    public required bool IsSugarFree { get; set; }

    /// <summary>
    /// Gets a description of cookie.
    /// </summary>
    /// <returns>A description of cookie.</returns>
    public override string GetDescription()
    {
        string sugarFree = IsSugarFree ? "Yes" : "No";

        return $"Candy: {Name}, Sugar-free: {sugarFree}, Price: {Price}, Weight: {Weight}";
    }
}