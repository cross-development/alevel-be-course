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

    public void Start()
    {
        Product[] products = _productService.GetAllProducts();

        foreach (Product product in products.Take(5))
        {
            _shoppingCartService.AddToCart(product);
        }

        Order? order = _shoppingCartService.PlaceOrder();

        if (order != null)
        {
            _orderService.NotifyBuyer(order);
        }
    }
}
