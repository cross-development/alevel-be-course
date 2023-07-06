using HW_2_2.Repositories;
using HW_2_2.Services;

namespace HW_2_2;

/// <summary>
/// Program entry point.
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        // Repositories
        var productRepository = new ProductRepository();

        // Services
        var productService = new ProductService(productRepository);
        var shoppingCartService = new ShoppingCartService();
        var loggerService = new LoggerService();
        var notificationService = new NotificationService(loggerService);
        var orderService = new OrderService(notificationService);

        // Application
        var app = new App(shoppingCartService, orderService, productService);

        app.Start();
    }
}
