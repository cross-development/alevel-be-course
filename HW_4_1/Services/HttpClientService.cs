using HW_4_1.Interfaces;

namespace HW_4_1.Services;

/// <summary>
/// HttpClient service.
/// </summary>
public sealed class HttpClientService : IHttpClientService
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
    public Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content = default(TRequest?))
        where TRequest : class
    {
        throw new NotImplementedException();
    }
}