namespace HW_2_1;

/// <summary>
/// Enum of log types.
/// </summary>
public enum LogType
{
    Info,
    Warning,
    Error,
}

/// <summary>
/// Logger service.
/// </summary>
internal class Logger
{
    private static Logger? _instance = null;
    private static readonly object Padlock = new object();
    public static Logger Instance
    {
        get
        {
            lock (Padlock)
            {
                return _instance ??= new Logger();
            }
        }
    }
    public StringBuilder Report { get; }

    private Logger()
    {
        Report = new StringBuilder();
    }

    /// <summary>
    /// This method displays a color message depending on the type of log.
    /// </summary>
    /// <param name="logType">Enum of log types.</param>
    /// <param name="message">Some message to display.</param>
    private void PrintLog(LogType logType, string message)
    {
        ConsoleColor previousColor = Console.ForegroundColor;

        Console.ForegroundColor = logType switch
        {
            LogType.Info => ConsoleColor.White,
            LogType.Warning => ConsoleColor.Yellow,
            LogType.Error => ConsoleColor.Red,
            _ => previousColor,
        };

        Console.WriteLine(message);

        Console.ForegroundColor = previousColor;
    }

    /// <summary>
    /// This method makes a log entry, adds it to the logger report, and displays it in the console.
    /// </summary>
    /// <param name="logType">Enum of log types.</param>
    /// <param name="message">Some message to display.</param>
    public void Log(LogType logType, string message)
    {
        string log = $"{DateTime.Now}: {logType}: {message}";

        Report.AppendLine(log);

        PrintLog(logType, log);
    }
}
