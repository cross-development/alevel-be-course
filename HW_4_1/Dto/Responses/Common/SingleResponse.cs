namespace HW_4_1.Dto.Responses.Common;

/// <summary>
/// Single response.
/// </summary>
/// <typeparam name="TData">The type returned from this method.</typeparam>
public sealed class SingleResponse<TData>
    where TData : class
{
    /// <summary>
    /// Gets or sets a single response data of type T.
    /// </summary>
    public TData? Data { get; set; }

    /// <summary>
    /// Gets or sets single response support data <see cref="Common.Support"/>.
    /// </summary>
    public Support? Support { get; set; }
}
