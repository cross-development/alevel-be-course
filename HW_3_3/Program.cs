namespace HW_3_3;

/// <summary>
/// Program entry point.
/// </summary>
internal sealed class Program
{
    /// <summary>
    /// Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    private static void Main(string[] args)
    {
        var class1 = new Class1();
        var class2 = new Class2();

        var resultDelegate = class2.Calc(class1.Multiply, 6, 2); // 12

        class1.OnShowDelegate(Show);
        class1.CallShowDelegate(resultDelegate(3)); // 12 % 3 = 0 == 0 => true
        class1.CallShowDelegate(resultDelegate(5)); // 12 % 5 = 2 == 0 => false
    }

    /// <summary>
    /// This method is used to show in the console the result of dividing without remainder.
    /// </summary>
    /// <param name="result">A bool result of dividing without remainder.</param>
    private static void Show(bool result)
    {
        Console.WriteLine($"Result: {result}");
    }
}
