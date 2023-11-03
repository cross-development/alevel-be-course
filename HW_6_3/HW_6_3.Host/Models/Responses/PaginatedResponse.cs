namespace HW_6_3.Host.Models.Responses;

public sealed class PaginatedResponse<T>
{
    public int PageIndex { get; init; }
    public int PageSize { get; init; }
    public long Count { get; init; }
    public IEnumerable<T> Data { get; init; } = null!;
}