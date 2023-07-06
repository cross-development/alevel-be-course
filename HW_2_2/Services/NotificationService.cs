using HW_2_2.Models;

namespace HW_2_2.Services;

/// <summary>
/// Notification Service.
/// </summary>
internal class NotificationService
{
    private readonly LoggerService _loggerService;

    public NotificationService(LoggerService loggerService)
    {
        _loggerService = loggerService;
    }

    /// <summary>
    /// Notification method.
    /// </summary>
    /// <param name="message">Some message to send.</param>
    public void Notify(string message)
    {
        _loggerService.Log(LogType.Info, message);
    }
}
