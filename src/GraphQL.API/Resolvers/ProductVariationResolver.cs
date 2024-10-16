namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Variation")]
    public class ProductVariationResolver
    {
        public Task<ICollection<ProductVariation>> GetProductVariationsAsync([Parent] Product product, [Service] IProductVariationRepository dataRepository) =>
            dataRepository.FindAllAsync(x => x.ProductId == product.Id);
    }
}
