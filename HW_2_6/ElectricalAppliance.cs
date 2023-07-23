namespace HW_2_6;

/// <summary>
/// ElectricalAppliance class.
/// </summary>
public abstract class ElectricalAppliance : IElectricalAppliance
{
    /// <summary>
    /// Gets or sets a name of an electrical appliance.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a power consumption of an electrical appliance.
    /// </summary>
    public double PowerConsumption { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ElectricalAppliance"/> class.
    /// </summary>
    /// <param name="name">A name of an electrical appliance.</param>
    /// <param name="powerConsumption">A power consumption of an electrical appliance.</param>
    protected ElectricalAppliance(string name, double powerConsumption)
    {
        Name = name;
        PowerConsumption = powerConsumption;
    }

    /// <summary>
    /// This method is used to plug in an electrical appliance.
    /// </summary>
    public virtual void PlugIn()
    {
        Console.WriteLine($"{Name} is plugged in.");
    }

    /// <summary>
    /// This method is used to plug out an electrical appliance.
    /// </summary>
    public void PlugOut()
    {
        Console.WriteLine($"{Name} is plugged out.");
    }

    /// <summary>
    /// This method is used to use an electrical appliance.
    /// </summary>
    public abstract void Use();
}