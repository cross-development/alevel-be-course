using EShop.Models;

namespace EShop.DTOs.Responses;

public sealed class CatalogResponseDto
{
    public int Page { get; init; }

    public int Limit { get; init; }

    public int Count { get; init; }

    public IEnumerable<CatalogItem> Data { get; init; }
}
