using HW_2_2.Models;

namespace HW_2_2.Services;

/// <summary>
/// Order Service.
/// </summary>
internal class OrderService
{
    private readonly NotificationService _notificationService;

    public OrderService(NotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    /// <summary>
    /// This method notifies a buyer using notification service.
    /// </summary>
    /// <param name="order">Instance of the Order Model.</param>
    public void NotifyBuyer(Order order)
    {
        _notificationService.Notify($"Your order #{order.OrderId} has been generated.");
        _notificationService.Notify("Your ordered products:");

        foreach (Product product in order.Products)
        {
            _notificationService.Notify(product.Description);
        }

    }
}
