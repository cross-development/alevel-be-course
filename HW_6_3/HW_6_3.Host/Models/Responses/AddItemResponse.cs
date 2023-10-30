namespace HW_6_3.Host.Models.Responses;

public sealed class AddItemResponse<T>
{
    public T Id { get; set; } = default!;
}