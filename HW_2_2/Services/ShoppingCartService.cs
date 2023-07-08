using HW_2_2.Models;

namespace HW_2_2.Services;

/// <summary>
/// Shopping Cart Service.
/// </summary>
internal class ShoppingCartService
{
    private readonly byte _maxCartLength = 10;
    private Product[] _cart = Array.Empty<Product>();

    /// <summary>
    /// The method is used to add product to the shopping cart.
    /// </summary>
    /// <param name="product">Some product.</param>
    public void AddToCart(Product product)
    {
        if (_cart.Length <= _maxCartLength)
        {
            Array.Resize(ref _cart, _cart.Length + 1);
            _cart[^1] = product;
        }
        else
        {
            Console.WriteLine("Cart is full. Cannot add more items.");
        }
    }

    /// <summary>
    /// The method is used to get all products in the shopping cart.
    /// </summary>
    /// <returns>The products from the shopping cart.</returns>
    public Product[] GetCartProducts()
    {
        return _cart;
    }

    /// <summary>
    /// The method is used to clear the shopping cart.
    /// </summary>
    public void ClearCart()
    {
        _cart = Array.Empty<Product>();
    }
}
