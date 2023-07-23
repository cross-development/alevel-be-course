using System.Reflection;

namespace HW_2_6;

/// <summary>
/// ElectricalApplianceExtensions class.
/// </summary>
public static class ElectricalApplianceExtensions
{
    /// <summary>
    /// This method is used to sort the electrical appliances.
    /// </summary>
    /// <param name="appliances">An array of an electrical appliance <see cref="IElectricalAppliance"/>.</param>
    /// <param name="parameter">Sorting parameter.</param>
    public static void SortByParameter(this IElectricalAppliance[] appliances, string parameter)
    {
        Array.Sort(appliances, (a, b) =>
            string.CompareOrdinal(GetPropertyValue(a, parameter), GetPropertyValue(b, parameter)));
    }

    /// <summary>
    /// This method is used to search an electrical appliance by some param and its value.
    /// </summary>
    /// <param name="appliances">An array of an electrical appliance <see cref="IElectricalAppliance"/>.</param>
    /// <param name="parameter">Search parameter.</param>
    /// <param name="value">Some value to search.</param>
    /// <returns>Found an electrical appliance <see cref="IElectricalAppliance"/>.</returns>
    public static IElectricalAppliance[] SearchByParameter(this IElectricalAppliance[] appliances, string parameter, string value)
    {
        return Array.FindAll(appliances, appliance =>
            GetPropertyValue(appliance, parameter).Equals(value, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// This method is used to get an electrical appliance property value.
    /// </summary>
    /// <param name="appliance">An electrical appliance which is the implementation of the <see cref="IElectricalAppliance"/> interface.</param>
    /// <param name="propertyName">Property name.</param>
    /// <returns>A property value or an empty string.</returns>
    private static string GetPropertyValue(IElectricalAppliance appliance, string propertyName)
    {
        PropertyInfo? propertyInfo = appliance.GetType().GetProperty(propertyName);

        return propertyInfo?.GetValue(appliance)?.ToString() ?? string.Empty;
    }
}