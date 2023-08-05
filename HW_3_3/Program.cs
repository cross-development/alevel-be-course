namespace HW_3_3;

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
        var class1 = new Class1();
        var class2 = new Class2();

        var showDelegate = class1.OnShowDelegate(Show);
        var multiplyDelegate = class1.Multiply;
        var resultDelegate = class2.Calc(multiplyDelegate, 6, 2); // 12

        showDelegate(resultDelegate(3)); // 12 % 3 = 0 == 0 => true
        showDelegate(resultDelegate(5)); // 12 % 5 = 2 == 0 => false
    }

    /// <summary>
    /// This method is used to show in the console the result of dividing without remainder.
    /// </summary>
    /// <param name="result">A bool result of dividing without remainder.</param>
    private static void Show(bool result) => Console.WriteLine($"Result: {result}");
}
