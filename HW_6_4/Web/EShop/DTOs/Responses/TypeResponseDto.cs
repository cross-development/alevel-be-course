using EShop.Models;

namespace EShop.DTOs.Responses;

public sealed class TypeResponseDto
{
    public IEnumerable<CatalogType> Data { get; set; }
}