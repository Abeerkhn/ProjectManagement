using GraphQL;

namespace Softwash.Infrastructure.Common.Shopify
{
    public interface IGraphQLService
    {
        Task<T> SendQueryAsync<T>(GraphQLRequest request);
    }
}
