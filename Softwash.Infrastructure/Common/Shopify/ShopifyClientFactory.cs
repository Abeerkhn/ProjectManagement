namespace Softwash.Infrastructure.Common.Shopify;
public class ShopifyClientFactory
{
    public static ShopifyApiClient CreateShopifyClient(IConfiguration configuration)
    {
        var shopifySection = configuration.GetSection("Shopify");
        var storeName = shopifySection["StoreName"];
        var accessToken = shopifySection["StorefrontAccessToken"];

        return new ShopifyApiClient(storeName, accessToken);
    }
}
