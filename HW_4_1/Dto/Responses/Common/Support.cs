namespace HW_4_1.Dto.Responses.Common;

/// <summary>
/// Support.
/// </summary>
public sealed class Support
{
    /// <summary>
    /// Gets or sets support url.
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// Gets or sets support test.
    /// </summary>
    public required string Text { get; set; }
}