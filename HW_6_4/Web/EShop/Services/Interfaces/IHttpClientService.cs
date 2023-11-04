namespace EShop.Services.Interfaces;

public interface IHttpClientService
{
    Task<TResponse> GetAsync<TResponse>(string url, HttpMethod method);

    Task<TResponse> GetAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest request);
}