using HW_2_2.Models;
using HW_2_2.Services;

namespace HW_2_2;

/// <summary>
/// Application entry point.
/// </summary>
internal class App
{
    private readonly ShoppingCartService _shoppingCartService;
    private readonly OrderService _orderService;
    private readonly ProductService _productService;

    public App(ShoppingCartService shoppingCartService, OrderService orderService, ProductService productService)
    {
        _shoppingCartService = shoppingCartService;
        _orderService = orderService;
        _productService = productService;
    }

    /// <summary>
    /// Application entry method.
    /// </summary>
    public void Start()
    {
        Product[] products = _productService.GetAllProducts();

        foreach (Product product in products.Take(5))
        {
            _shoppingCartService.AddToCart(product);
        }

        Product[] cartProducts = _shoppingCartService.GetCartProducts();

        if (cartProducts.Length != 0)
        {
            _orderService.PlaceOrder(cartProducts, NotificationType.Email);
            _shoppingCartService.ClearCart();
        }
        else
        {
            Console.WriteLine("Cart is empty. Cannot place an order.");
        }

        Console.ReadLine();
    }
}
