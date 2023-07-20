using HW_2_5.Enums;

namespace HW_2_5.Interfaces;

/// <summary>
/// ILoggerService interface.
/// </summary>
public interface ILoggerService
{
    /// <summary>
    /// This method makes a log entry, adds it to the logger report, and displays it in the console.
    /// </summary>
    /// <param name="logType">Log types which are described in the <see cref="LogType"/> enum.</param>
    /// <param name="message">Some message to display.</param>
    public void Log(LogType logType, string message);
}