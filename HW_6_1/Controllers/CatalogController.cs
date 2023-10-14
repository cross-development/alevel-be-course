using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using HW_6_1.Data;

namespace HW_6_1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public IEnumerable<Product> GetAllProducts()
    {
        var products = Enumerable.Range(1, 5)
            .Select(index => new Product
            {
                Id = Guid.NewGuid(),
                Name = $"Product-{index}",
                Description = $"Description for the product-{index}",
                Price = Random.Shared.Next(10, 1000),
            }).ToList();

        return products;
    }
}
