using System.Text;
using System.Text.Json;
using Polly;

namespace ECommerce.TechnicalTest.Cross.Util;

public class RetryingHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly IAsyncPolicy<HttpResponseMessage> _policy;

    public RetryingHttpClient(HttpClient httpClient, IAsyncPolicy<HttpResponseMessage> policy)
    {
        _httpClient = httpClient;
        _policy = policy;
    }

    public async Task<T?> GetAsync<T>(string uri)
    {
        var response = await _policy.ExecuteAsync(() => _httpClient.GetAsync(uri));
        if (!response.IsSuccessStatusCode) return default;

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<TResponse?> PostAsync<TRequest, TResponse>(string uri, TRequest data)
    {
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _policy.ExecuteAsync(() => _httpClient.PostAsync(uri, content));
        if (!response.IsSuccessStatusCode) return default;

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}