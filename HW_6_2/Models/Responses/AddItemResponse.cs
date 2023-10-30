namespace HW_6_2.Models.Responses;

public sealed class AddItemResponse<T>
{
    public T Id { get; set; } = default!;
}