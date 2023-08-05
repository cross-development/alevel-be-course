namespace HW_3_3;

/// <summary>
/// Class 2.
/// </summary>
public sealed class Class2
{
    /// <summary>
    /// This field is used to store the result of multiplication.
    /// </summary>
    private int _result;

    /// <summary>
    /// This method is used to calculate the result of multiplication two numbers.
    /// </summary>
    /// <param name="multiplyDelegate">The multiply delegate.</param>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>The instance of the multiply delegate.</returns>
    public Func<int, bool> Calc(Func<int, int, int> multiplyDelegate, int x, int y)
    {
        _result = multiplyDelegate(x, y);

        Func<int, bool> resultDelegate = Result;

        return resultDelegate;
    }

    /// <summary>
    /// This method is used to calculate whether the number is divisible without a remainder or not.
    /// </summary>
    /// <param name="x">A number to check.</param>
    /// <returns>The bool result of dividing without remainder.</returns>
    public bool Result(int x) => _result % x == 0;
}