using ECommerce.TechnicalTest.Cross.Util;
using ECommerce.TechnicalTest.Domain.DTO;
using Microsoft.Extensions.Configuration;

namespace ECommerce.TechnicalTest.Services;

public class ProductVerifyService
{
    private readonly RetryingHttpClient _client;
    private readonly IConfiguration _configurationInstance;

    public ProductVerifyService(RetryingHttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configurationInstance = configuration;
        }

        public virtual async Task<bool> ProductExistsAsync(int productId)
        {
            
            string baseUrl=this._configurationInstance["BaseProductsApiUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("BaseProductsApiUrl is not configured.");
            var result = await _client.GetAsync<ProductDto>($"{baseUrl}/Products/{productId}");
            return result!=null;
        }
}

