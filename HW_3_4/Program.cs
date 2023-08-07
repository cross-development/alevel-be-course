using static HW_3_4.Calculator;

namespace HW_3_4;

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
        Calculator calculator = new Calculator();

        calculator.OnCalculate += Add;
        calculator.OnCalculate += Add;

        int sum = Calculate(calculator.CalculateSum, 5, 10);

        Console.WriteLine($"Sum is: {sum}\n");

        LinqPractice.RunLinqMethods();
    }

    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>Result of adding two numbers.</returns>
    private static int Add(int x, int y) => x + y;

    private static int Calculate(CalculateDelegate calculateDelegate, int x, int y)
    {
        try
        {
            return calculateDelegate(x, y);
        }
        catch (Exception ex)
        {
            throw new Exception("Error in calculation: " + ex.Message);
        }
    }
}
