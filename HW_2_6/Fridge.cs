namespace HW_2_6;

/// <summary>
/// Fridge class.
/// </summary>
public sealed class Fridge : ElectricalAppliance
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Fridge"/> class.
    /// </summary>
    /// <param name="name">A name of an electrical appliance.</param>
    /// <param name="powerConsumption">A power consumption of an electrical appliance.</param>
    public Fridge(string name, double powerConsumption)
        : base(name, powerConsumption)
    {
    }

    /// <summary>
    /// This method is used to use an electrical appliance.
    /// </summary>
    public override void Use()
    {
        Console.WriteLine($"{Name} is keeping food fresh.");
    }
}