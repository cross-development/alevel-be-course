namespace HW_2_1;

/// <summary>
/// Startup class.
/// </summary>
internal class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    /// <param name="args">Some string arguments.</param>
    private static void Main(string[] args)
    {
        Starter starter = new Starter();
        starter.Run();

        Console.ReadKey();
    }
}
