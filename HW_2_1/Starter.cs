namespace HW_2_1;

/// <summary>
/// The startup class that runs the logging processing
/// </summary>
internal class Starter
{
    private static readonly Logger Logger = Logger.Instance;
    private readonly Actions _actions = new Actions(Logger);
    private readonly Random _random = new Random();

    /// <summary>
    /// This method starts log processing and randomly calls one of the three action methods.
    /// At the end of the log processing, it writes a logger report to the log.txt file.
    /// </summary>
    /// <exception cref="InvalidOperationException">In case something went wrong.</exception>
    public void Run()
    {
        for (int i = 0; i <= 100; i++)
        {
            int randomMethodNumber = _random.Next(1, 4);

            Result result = randomMethodNumber switch
            {
                1 => _actions.CallInfoAction(),
                2 => _actions.CallWarningAction(),
                3 => _actions.CallErrorAction(),
                _ => throw new InvalidOperationException("Invalid random method number"),
            };

            if (!result.Status)
            {
                Logger.Log(LogType.Error, $"Action failed by a reason: {result.Error}");
            }
        }

        string loggerReport = Logger.Report.ToString();

        File.WriteAllText("log.txt", loggerReport);
    }
}
