namespace HW_6_2.Models.Requests;

public sealed class PaginatedRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}