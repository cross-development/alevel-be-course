using HW_2_2.Models;

namespace HW_2_2.Services;

/// <summary>
/// Shopping Cart Service.
/// </summary>
internal class ShoppingCartService
{
    private int _productCount = 0;
    private readonly byte _maxCartLength = 10;
    private Product[] _cart = Array.Empty<Product>();

    private string GenerateOrderId()
    {
        return Guid.NewGuid().ToString();
    }

    public void AddToCart(Product product)
    {
        if (_cart.Length <= _maxCartLength)
        {
            Array.Resize(ref _cart, _cart.Length + 1);
            _cart[_cart.Length - 1] = product;
            _productCount++;

            Console.WriteLine($"{product.Name} added to the cart.");
        }
        else
        {
            Console.WriteLine("Cart is full. Cannot add more items.");
        }
    }

    public Order? PlaceOrder()
    {
        if (_productCount == 0)
        {
            return null;
        };

        Order order = new Order { OrderId = GenerateOrderId(), Products = _cart };

        _cart = Array.Empty<Product>();
        _productCount = 0;

        return order;
    }
}
