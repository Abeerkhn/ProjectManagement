using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class GraphQLService : IGraphQLService
{
    readonly GraphQLHttpClient _client;

    public GraphQLService(IConfiguration configuration)
    {
        var shopifySection = configuration.GetSection("Shopify");
        var storeName = shopifySection["StoreName"];
        var accessToken = shopifySection["StorefrontAccessToken"];
        var graphqlEndpoint = $"https://southeastsoftwash.myshopify.com/api/2023-01/graphql.json";

        _client = new GraphQLHttpClient(graphqlEndpoint, new SystemTextJsonSerializer());
        _client.HttpClient.DefaultRequestHeaders.Add("X-Shopify-Storefront-Access-Token", accessToken);
    }

    public async Task<T> SendQueryAsync<T>(GraphQLRequest request)
    {
        var response = await _client.SendQueryAsync<T>(request);
        return response.Data;
    }
}
