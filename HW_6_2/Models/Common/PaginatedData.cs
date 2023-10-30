namespace HW_6_2.Models.Common;

public sealed class PaginatedData<T>
{
    public long TotalCount { get; init; }
    public IEnumerable<T> Data { get; init; } = null!;
}