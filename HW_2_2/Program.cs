using HW_2_2.Repositories;
using HW_2_2.Services;

namespace HW_2_2;

/// <summary>
/// Program entry point.
/// </summary>
internal class Program
{
    /// <summary>
    /// Program entry method.
    /// </summary>
    /// <param name="args">Some arguments.</param>
    static void Main(string[] args)
    {
        // Repositories
        var productRepository = new ProductRepository();

        // Services
        var notificationService = new NotificationService();
        var shoppingCartService = new ShoppingCartService();
        var orderService = new OrderService(notificationService);
        var productService = new ProductService(productRepository);

        // Application
        var app = new App(shoppingCartService, orderService, productService);

        app.Start();
    }
}
