namespace Catalog.Host.Models.Common;

public sealed class PaginatedData<T>
{
    public int TotalCount { get; init; }

    public IEnumerable<T> Data { get; init; } = null!;
}