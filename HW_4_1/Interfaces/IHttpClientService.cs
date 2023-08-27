namespace HW_4_1.Interfaces;

/// <summary>
/// HttpClient Service interface.
/// </summary>
public interface IHttpClientService
{
    /// <summary>
    /// Send async request.
    /// </summary>
    /// <typeparam name="TResponse">The type returned from this method.</typeparam>
    /// <param name="url">Request url.</param>
    /// <param name="method">Request method.</param>
    /// <param name="content">Request body if any.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null);
}