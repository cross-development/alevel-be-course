namespace HW_3_4;

/// <summary>
/// Calculator class.
/// </summary>
public class Calculator
{
    /// <summary>
    /// Delegate for methods of calculation.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>Result of adding two numbers.</returns>
    public delegate int CalculateDelegate(int x, int y);

    /// <summary>
    /// Event for delegates of calculation.
    /// </summary>
    public event CalculateDelegate? OnCalculate;

    /// <summary>
    /// Calculate sum of two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>Result of adding two numbers.</returns>
    public int CalculateSum(int x, int y)
    {
        int sum = 0;

        if (OnCalculate == null)
        {
            return sum;
        }

        Delegate[] subscribers = OnCalculate.GetInvocationList();

        sum = subscribers
            .Cast<CalculateDelegate>()
            .Sum(del => del(x, y));

        return sum;
    }
}