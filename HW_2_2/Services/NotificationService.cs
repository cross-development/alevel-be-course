using HW_2_2.Models;

namespace HW_2_2.Services;

/// <summary>
/// Notification Service.
/// </summary>
internal class NotificationService
{
    /// <summary>
    /// The common notification method.
    /// </summary>
    /// <param name="notificationType">Shipping method.</param>
    /// <param name="message">Some message to send.</param>
    public void Notify(NotificationType notificationType, string message)
    {
        switch (notificationType)
        {
            case NotificationType.Email:
                NotifyByEmail(message);
                break;
            case NotificationType.Post:
                NotifyByPost(message);
                break;
            default:
                NotifyByEmail(message);
                break;
        }
    }

    /// <summary>
    /// The method is used to notify a buyer by email.
    /// </summary>
    /// <param name="message">Some message to send.</param>
    private void NotifyByEmail(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Your invoice will be shipped by email.");
    }

    /// <summary>
    /// The method is used to notify a buyer by post.
    /// </summary>
    /// <param name="message">Some message to send.</param>
    private void NotifyByPost(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Your invoice will be shipped by post.");
    }
}
