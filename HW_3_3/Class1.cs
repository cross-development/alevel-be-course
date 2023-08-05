namespace HW_3_3;

/// <summary>
/// Class 1.
/// </summary>
public sealed class Class1
{
    /// <summary>
    /// This delegate refers to the Show method.
    /// </summary>
    /// <param name="result">A bool result of dividing without remainder.</param>
    public delegate void ShowDelegate(bool result);

    /// <summary>
    /// This method is used to set the show delegate.
    /// </summary>
    /// <param name="showDelegate">The show delegate.</param>
    /// <returns>The instance of the show delegate.</returns>
    public ShowDelegate OnShowDelegate(ShowDelegate showDelegate) => showDelegate;

    /// <summary>
    /// This method is used to multiply two numbers.
    /// </summary>
    /// <param name="x">The first number.</param>
    /// <param name="y">The second number.</param>
    /// <returns>The result of multiplication.</returns>
    public int Multiply(int x, int y) => x * y;
}