namespace Softwash.Infrastructure.Common.Shopify;

public class ShopifyApiClient
{
    private readonly RestClient _client;

    public ShopifyApiClient(string storeName, string accessToken)
    {
        if (string.IsNullOrEmpty(storeName))
            throw new ArgumentNullException(nameof(storeName));
        if (string.IsNullOrEmpty(accessToken))
            throw new ArgumentNullException(nameof(accessToken));
        _client = new RestClient(ShopifyStore.BuildBaseUrl(storeName));
        _client.AddDefaultHeader("X-Shopify-Storefront-Access-Token", accessToken);
    }

    public RestRequest CreateRequest(string endpoint, Method method)
    {
        return new RestRequest(endpoint, method);
    }

    public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
    {
        var response = await _client.ExecuteAsync<T>(request);
        if (!response.IsSuccessful)
            throw new Exception($"Error: {response.StatusDescription}");
        return response.Data;
    }

}
