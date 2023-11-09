using System.Net.Mime;
using System.Text;
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

    public Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method) =>
        SendAsync<TResponse, object, object>(url, method);

    public Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest request) =>
        SendAsync<TResponse, object, object>(url, method, request);

    public async Task<TResponse> SendAsync<TResponse, TRequest, TContent>(
        string url, HttpMethod method, TRequest request = default, TContent content = default)
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();

        var queryString = GetQueryString(request);
        var stringContent = GetStringContent(content);

        httpMessage.RequestUri = new Uri($"{_apiOptions.ApiUrl}{url}{queryString}");
        httpMessage.Content = stringContent;
        httpMessage.Method = method;

        var result = await client.SendAsync(httpMessage);

        if (!result.IsSuccessStatusCode)
        {
            return default;
        }

        var resultContent = await result.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<TResponse>(resultContent);

        return response;
    }

    private string GetQueryString<TRequest>(TRequest request)
    {
        if (request == null)
        {
            return string.Empty;
        }

        var builder = new UriBuilder();

        var query = HttpUtility.ParseQueryString(builder.Query);

        foreach (var property in request.GetType().GetProperties())
        {
            query[property.Name] = property.GetValue(request)?.ToString();
        }

        builder.Query = query.ToString() ?? string.Empty;

        _logger.LogInformation($"[HttpClientService] --> BUILDER QUERY: {builder.Query}");

        return builder.Query;
    }

    private StringContent GetStringContent<TContent>(TContent content)
    {
        var serializedContent = JsonConvert.SerializeObject(content);
        var stringContent = new StringContent(serializedContent, Encoding.UTF8, MediaTypeNames.Application.Json);

        _logger.LogInformation($"[HttpClientService] --> STRING CONTENT: {stringContent}");

        return stringContent;
    }
}