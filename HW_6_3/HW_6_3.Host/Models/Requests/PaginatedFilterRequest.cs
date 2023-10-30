namespace HW_6_3.Host.Models.Requests;

public sealed class PaginatedFilterRequest
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int? TypeId { get; set; }
    public int? BrandId { get; set; }
}