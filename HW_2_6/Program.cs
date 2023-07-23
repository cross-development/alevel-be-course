namespace HW_2_6;

/// <summary>
/// Program entry point.
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    private static void Main(string[] args)
    {
        Fridge fridge = new Fridge("Samsung Fridge", 200);
        Television television = new Television("LG Television", 100);
        Microwave microwave = new Microwave("Panasonic Microwave", 150);

        IElectricalAppliance[] appliances = { fridge, television, microwave };
        Apartment apartment = new Apartment(appliances);

        // Calculate power consumption
        double totalPowerConsumption = apartment.CalculatePowerConsumption();
        Console.WriteLine("Total Power Consumption: " + totalPowerConsumption + " Watts");

        // Sort by param
        IElectricalAppliance[] appliancesInApartment = apartment.GetAllElectricalAppliances();

        Console.WriteLine();
        Console.WriteLine("An electrical appliances before sorting:");

        for (var i = 0; i < appliancesInApartment.Length; i++)
        {
            Console.WriteLine($"{i + 1} item in the apartment is {appliancesInApartment[i].Name}");
        }

        appliancesInApartment.SortByParameter("Name");

        Console.WriteLine();
        Console.WriteLine("An electrical appliances after sorting:");

        for (var i = 0; i < appliancesInApartment.Length; i++)
        {
            Console.WriteLine($"{i + 1} item in the apartment is {appliancesInApartment[i].Name}");
        }

        Console.WriteLine();

        // Search by param and value
        IElectricalAppliance[] foundAppliances = appliancesInApartment.SearchByParameter("PowerConsumption", "150");

        foreach (var appliance in foundAppliances)
        {
            Console.WriteLine($"Found Appliance: {appliance.Name}");

            appliance.PlugIn();
            appliance.Use();
            appliance.PlugOut();

            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
