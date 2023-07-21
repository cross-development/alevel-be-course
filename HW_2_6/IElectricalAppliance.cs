namespace HW_2_6;

/// <summary>
/// IElectricalAppliance interface.
/// </summary>
public interface IElectricalAppliance
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
    /// This method is used to plug in an electrical appliance.
    /// </summary>
    public void PlugIn();

    /// <summary>
    /// This method is used to plug out an electrical appliance.
    /// </summary>
    public void PlugOut();

    /// <summary>
    /// This method is used to use an electrical appliance.
    /// </summary>
    public void Use();
}