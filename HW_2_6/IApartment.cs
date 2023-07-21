namespace HW_2_6;

/// <summary>
/// Apartment interface.
/// </summary>
public interface IApartment
{
    /// <summary>
    /// This method is used to calculate a power consumption of an electrical appliance.
    /// </summary>
    /// <returns>Total power  consumption of the electrical appliances.</returns>
    public double CalculatePowerConsumption();

    /// <summary>
    /// This method is used to get all electrical appliances.
    /// </summary>
    /// <returns>An array of an electrical appliance <see cref="IElectricalAppliance"/>.</returns>
    public IElectricalAppliance[] GetAllElectricalAppliances();
}