using System.Text;
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
    /// The method is used to checkout from the shopping cart.
    /// </summary>
    /// <param name="cartProducts">The products from the shopping cart.</param>
    /// <returns>The generated order.</returns>
    private Order MakeOrder(Product[] cartProducts)
    {
        return new Order { OrderId = Guid.NewGuid().ToString(), Products = cartProducts };
    }

    /// <summary>
    /// The method is used to generate an invoice from the order.
    /// </summary>
    /// <param name="order">The order.</param>
    /// <returns>The generated invoice.</returns>
    private string GenerateInvoice(Order order)
    {
        StringBuilder invoice = new StringBuilder();

        invoice.AppendLine($"Your order #{order.OrderId} has been generated.\n");
        invoice.AppendLine("Your ordered products:");

        for (int i = 0; i < order.Products.Length; i++)
        {
            invoice.AppendLine($"{i + 1}) {order.Products[i].Description}");
        }

        return invoice.ToString();
    }

    /// <summary>
    /// The method is used to notify a buyer.
    /// </summary>
    /// <param name="invoice">The invoice.</param>
    /// <param name="sendBy">Type of invoice sending.</param>
    private void NotifyBuyer(string invoice, NotificationType sendBy)
    {
        _notificationService.Notify(sendBy, invoice);
    }

    /// <summary>
    /// The method is used to place the order and notify a buyer with the invoice.
    /// </summary>
    /// <param name="cartProducts">The products from the shopping cart.</param>
    /// <param name="sendBy">Type of invoice sending.</param>
    public void PlaceOrder(Product[] cartProducts, NotificationType sendBy)
    {
        Order order = MakeOrder(cartProducts);
        string invoice = GenerateInvoice(order);

        NotifyBuyer(invoice, sendBy);
    }
}
