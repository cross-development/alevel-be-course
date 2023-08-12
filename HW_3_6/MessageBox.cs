namespace HW_3_6;

/// <summary>
/// MessageBox class.
/// </summary>
public class MessageBox
{
    /// <summary>
    /// Used to indicate that the window has been closed.
    /// </summary>
    public event Action<StateEnum>? WindowClosed;

    /// <summary>
    /// Used to write a message to the console whether a window is opened or not.
    /// </summary>
    public async void Open()
    {
        Console.WriteLine("Window is opened");

        await Task.Delay(3000);

        Console.WriteLine("Window was closed by the user");

        StateEnum state = GetRandomState();

        WindowClosed?.Invoke(state);
    }

    /// <summary>
    /// Used to get random state <see cref="StateEnum"/>.
    /// </summary>
    /// <returns>One of the defined state: 0 - Ok, 1 - Cancel.</returns>
    private StateEnum GetRandomState()
    {
        var random = new Random();

        return (StateEnum)random.Next(0, 2);
    }
}