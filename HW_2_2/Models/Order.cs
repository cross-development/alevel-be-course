namespace HW_2_2.Models;

/// <summary>
/// Order Model.
/// </summary>
internal class Order
{
    public required string OrderId { get; set; }
    public required Product[] Products { get; set; }
}
