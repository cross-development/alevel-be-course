namespace HW_2_6;

/// <summary>
/// Apartment class.
/// </summary>
public sealed class Apartment : IApartment
{
    private readonly IElectricalAppliance[] _appliances;

    /// <summary>
    /// Initializes a new instance of the <see cref="Apartment"/> class.
    /// </summary>
    /// <param name="appliances">An array of an electrical appliance <see cref="IElectricalAppliance"/>.</param>
    public Apartment(IElectricalAppliance[] appliances) => _appliances = appliances;

    /// <summary>
    /// This method is used to calculate a power consumption of an electrical appliance.
    /// </summary>
    /// <returns>Total power  consumption of the electrical appliances.</returns>
    public double CalculatePowerConsumption() => _appliances.Sum(appliance => appliance.PowerConsumption);

    /// <summary>
    /// This method is used to get all electrical appliances.
    /// </summary>
    /// <returns>An array of an electrical appliance <see cref="IElectricalAppliance"/>.</returns>
    public IElectricalAppliance[] GetAllElectricalAppliances() => _appliances;
}