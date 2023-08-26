using Newtonsoft.Json;

namespace HW_4_1.Dto.Responses.Common;

/// <summary>
/// Collection response.
/// </summary>
/// <typeparam name="TData">The type returned from this method.</typeparam>
public sealed class CollectionResponse<TData>
    where TData : class
{
    /// <summary>
    /// Gets or sets a current page.
    /// </summary>
    public required int Page { get; set; }

    /// <summary>
    /// Gets or sets a number of items per page.
    /// </summary>
    [JsonProperty("per_page")]
    public required int PerPage { get; set; }

    /// <summary>
    /// Gets or sets total items in the collection.
    /// </summary>
    public required int Total { get; set; }

    /// <summary>
    /// Gets or sets total pages in the collection.
    /// </summary>
    [JsonProperty("total_pages")]
    public required int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets a single response data of type T.
    /// </summary>
    public required ICollection<TData> Data { get; set; }

    /// <summary>
    /// Gets or sets single response support data <see cref="Common.Support"/>.
    /// </summary>
    public required Support Support { get; set; }
}
