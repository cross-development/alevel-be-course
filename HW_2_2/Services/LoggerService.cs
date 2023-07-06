using System.Text;
using HW_2_2.Models;

namespace HW_2_2.Services;

/// <summary>
/// Logger Service
/// </summary>
internal class LoggerService
{
    public StringBuilder Report { get; }

    public LoggerService()
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
