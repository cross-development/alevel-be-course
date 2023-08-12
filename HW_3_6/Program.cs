namespace HW_3_6;

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
        var completionSource = new TaskCompletionSource<StateEnum>();

        var messageBox = new MessageBox();
        messageBox.WindowClosed += completionSource.SetResult;
        messageBox.Open();

        HandleWindowClosedResult(completionSource.Task.Result);
    }

    /// <summary>
    /// Used to print a message depending on the operation state.
    /// </summary>
    /// <param name="state">The operation state <see cref="StateEnum"/>.</param>
    private static void HandleWindowClosedResult(StateEnum state)
    {
        switch (state)
        {
            case StateEnum.Ok:
                Console.WriteLine("The operation has been confirmed");
                break;

            case StateEnum.Cancel:
                Console.WriteLine("The operation was rejected");
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}
