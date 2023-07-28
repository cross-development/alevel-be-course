namespace HW_3_1;

/// <summary>
/// Program entry point.
/// </summary>
internal class Program
{
    /// <summary>
    /// Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    private static void Main(string[] args)
    {
        var collection1 = new MyCustomCollection<int>();

        Console.WriteLine($"The number of elements in {nameof(collection1)} before adding elements is {collection1.Count}");

        collection1.Add(2);
        collection1.Add(1);
        collection1.Add(3);
        collection1.Add(4);

        Console.WriteLine($"The number of elements in {nameof(collection1)} after adding elements is {collection1.Count}");

        Console.WriteLine();
        Console.WriteLine($"The {nameof(collection1)} before sorting");

        foreach (var item in collection1)
        {
            Console.WriteLine(item);
        }

        collection1.Sort();

        Console.WriteLine();
        Console.WriteLine($"The {nameof(collection1)} after sorting");

        foreach (var item in collection1)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        Console.WriteLine($"The element by index 1 before setting to the element's default value is {collection1[1]}");

        collection1.SetDefaultAt(1);

        Console.WriteLine($"The element by index 1 after setting to the element's default value is {collection1[1]}");

        Console.ReadKey();
    }
}
