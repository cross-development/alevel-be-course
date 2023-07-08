using HW_2_2.Entities;

namespace HW_2_2.Repositories;

/// <summary>
/// Product Repository.
/// </summary>
internal class ProductRepository
{
    private readonly ProductEntity[] _mockStorage = new ProductEntity[]
    {
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 1", Price = 100},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 2", Price = 200},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 3", Price = 300},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 4", Price = 400},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 5", Price = 500},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 6", Price = 600},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 7", Price = 700},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 8", Price = 800},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 9", Price = 900},
        new ProductEntity { Id = Guid.NewGuid().ToString(), Name = "Product 10", Price = 1000},
    };

    /// <summary>
    /// The method is used to get all products from the storage.
    /// </summary>
    /// <returns>All products in the storage.</returns>
    public ProductEntity[] GetAllProducts() => _mockStorage;
}
