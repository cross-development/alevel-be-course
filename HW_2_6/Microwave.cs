namespace HW_2_6;

/// <summary>
/// Microwave class.
/// </summary>
public sealed class Microwave : ElectricalAppliance
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Microwave"/> class.
    /// </summary>
    /// <param name="name">A name of an electrical appliance.</param>
    /// <param name="powerConsumption">A power consumption of an electrical appliance.</param>
    public Microwave(string name, double powerConsumption)
        : base(name, powerConsumption)
    {
    }

    /// <summary>
    /// This method is used to use an electrical appliance.
    /// </summary>
    public override void Use()
    {
        Console.WriteLine($"{Name} is heating food.");
    }
}