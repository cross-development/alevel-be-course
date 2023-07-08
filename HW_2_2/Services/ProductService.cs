using HW_2_2.Entities;
using HW_2_2.Models;
using HW_2_2.Repositories;

namespace HW_2_2.Services;

/// <summary>
/// Product Service.
/// </summary>
internal class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// This method is used to get all products.
    /// </summary>
    /// <returns>All products in the storage.</returns>
    public Product[] GetAllProducts()
    {
        ProductEntity[] productEntities = _productRepository.GetAllProducts();
        Product[] products = new Product[productEntities.Length];

        // Map the Product entity to the Product model
        for (int i = 0; i < productEntities.Length; i++)
        {
            var currentProductEntity = productEntities[i];

            products[i] = new Product
            {
                Id = currentProductEntity.Id,
                Name = currentProductEntity.Name,
                Price = currentProductEntity.Price,
                Description = $"Product {currentProductEntity.Name} costs {currentProductEntity.Price}"
            };
        }

        return products;
    }
}
