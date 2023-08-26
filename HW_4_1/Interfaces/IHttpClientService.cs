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
    /// <typeparam name="TRequest">The type of the request body.</typeparam>
    /// <param name="url">Request url.</param>
    /// <param name="method">Request method.</param>
    /// <param name="content">Request body if any.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content = null)
        where TRequest : class;
}