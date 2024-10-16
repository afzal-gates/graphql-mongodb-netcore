namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "ProductStock")]
    public class ProductStockResolver
    {
        public Task<ICollection<ProductStock>> GetProductVariationStockAsync([Parent] ProductVariation productVariation, [Service] IProductStockRepository dataRepository) =>
            dataRepository.FindAllAsync(x => x.ProductId == productVariation.ProductId && x.ProductVariationId == productVariation.Id);
        public Task<ICollection<ProductStock>> GetProductStockAsync([Parent] Product product, [Service] IProductStockRepository dataRepository) =>
            dataRepository.FindAllAsync(x => x.ProductId == product.Id);
    }
}
