using ECommerce.TechnicalTest.Cross.Util;

namespace ECommerce.TechnicalTest.Services;

public class ProductVerifierClient
{
    private readonly RetryingHttpClient _httpClient;

    public ProductVerifierClient(RetryingHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ProductExistsAsync(int productId)
    {
        var result = await _httpClient.GetAsync<bool>($"/api/products/exists/{productId}");
        return result;
    }
}


