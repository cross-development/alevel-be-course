namespace HW_6_3.Host.Models.Common;

public sealed class PaginatedData<T>
{
    public long TotalCount { get; init; }
    public IEnumerable<T> Data { get; init; } = null!;
}