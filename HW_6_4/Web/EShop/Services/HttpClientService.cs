using System.Web;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using EShop.Configurations;
using EShop.Services.Interfaces;

namespace EShop.Services;

public sealed class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ApiConfiguration _apiOptions;
    private readonly ILogger<HttpClientService> _logger;

    public HttpClientService(
        IHttpClientFactory clientFactory,
        IOptions<ApiConfiguration> apiOptions,
        ILogger<HttpClientService> logger)
    {
        _apiOptions = apiOptions.Value;
        _clientFactory = clientFactory;
        _logger = logger;
    }

    public Task<TResponse> GetAsync<TResponse>(string url, HttpMethod method) =>
         GetAsync<TResponse, object>(url, method, null);

    public async Task<TResponse> GetAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest request)
    {
        var client = _clientFactory.CreateClient();

        var builder = new UriBuilder($"{_apiOptions.ApiUrl}{url}");
        var query = HttpUtility.ParseQueryString(builder.Query);

        if (request != null)
        {
            foreach (var property in request.GetType().GetProperties())
            {
                query[property.Name] = property.GetValue(request)?.ToString();

                _logger.LogInformation($"[HttpClientService]: QUERY PARAM: {property.Name}, VALUE: {query[property.Name]}");
            }
        }

        builder.Query = query.ToString() ?? string.Empty;

        _logger.LogInformation($"[HttpClientService]: BUILDER QUERY IS: {builder.Query}");

        var requestUri = builder.Uri.ToString();

        _logger.LogInformation($"[HttpClientService]: REQUEST URI IS: {requestUri}");

        var result = await client.GetAsync(requestUri);

        if (!result.IsSuccessStatusCode)
        {
            return default;
        }

        var resultContent = await result.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<TResponse>(resultContent);

        return response;
    }
}