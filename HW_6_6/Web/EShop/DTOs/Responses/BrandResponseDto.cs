using EShop.Models;

namespace EShop.DTOs.Responses;

public sealed class BrandResponseDto
{
    public IEnumerable<CatalogBrand> Data { get; set; }
}