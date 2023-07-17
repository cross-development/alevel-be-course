using HW_2_5.Enums;
using HW_2_5.Interfaces;

namespace HW_2_5.Services;

/// <summary>
/// LoggerService class.
/// </summary>
public sealed class LoggerService : ILoggerService
{
    private readonly IFileService _fileService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggerService"/> class.
    /// </summary>
    /// <param name="fileService">The implementation of the <see cref="IFileService"/> interface.</param>
    public LoggerService(IFileService fileService)
    {
        _fileService = fileService;
    }

    /// <summary>
    /// This method is used to log messages.
    /// </summary>
    /// <param name="logType">Log types which are described in the <see cref="LogType"/> enum.</param>
    /// <param name="message">Some message to display.</param>
    public void Log(LogType logType, string message)
    {
        DateTime logTime = DateTime.Now;
        string log = $"{logTime}: {logType}: {message}";

        _fileService.WriteToFile(logType, log);
        _fileService.DeleteOldestFile(maxFileCount: 3);
    }
}