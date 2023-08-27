using System.Net.Mime;
using System.Text;
using HW_4_1.Configs;
using HW_4_1.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HW_4_1.Services;

/// <summary>
/// HttpClient service.
/// </summary>
public sealed class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiConfig _apiOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpClientService"/> class.
    /// </summary>
    /// <param name="httpClientFactory">The implementation of the <see cref="IHttpClientFactory"/> interface.</param>
    /// <param name="apiOptions">The instance of the <see cref="ApiConfig"/> class.</param>
    public HttpClientService(IHttpClientFactory httpClientFactory, IOptions<ApiConfig> apiOptions)
    {
        _httpClientFactory = httpClientFactory;
        _apiOptions = apiOptions.Value;
    }

    /// <summary>
    /// Send async request.
    /// </summary>
    /// <typeparam name="TResponse">The type returned from this method.</typeparam>
    /// <param name="url">Request url.</param>
    /// <param name="method">Request method.</param>
    /// <param name="content">Request body if any.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task<TResponse> SendAsync<TResponse>(string url, HttpMethod method, object? content = null)
    {
        var httpMessage = new HttpRequestMessage();

        httpMessage.RequestUri = new Uri($"{_apiOptions.Host}/{url}");
        httpMessage.Method = method;

        if (content != null)
        {
            var serializedBody = SerializeRequestContent(content);

            httpMessage.Content = new StringContent(serializedBody, Encoding.Unicode, MediaTypeNames.Application.Json);
        }

        var httpClient = _httpClientFactory.CreateClient();
        var result = await httpClient.SendAsync(httpMessage);

        var resultContent = await result.Content.ReadAsStringAsync();

        if (!result.IsSuccessStatusCode)
        {
            return default!;
        }

        var response = JsonConvert.DeserializeObject<TResponse>(resultContent);

        return response!;
    }

    /// <summary>
    /// Used to serialize content to JSON.
    /// </summary>
    /// <param name="content">Some content to serialize.</param>
    /// <returns>Serialized content.</returns>
    private string SerializeRequestContent(object? content)
    {
        var jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        return JsonConvert.SerializeObject(content, jsonSerializerSettings);
    }
}