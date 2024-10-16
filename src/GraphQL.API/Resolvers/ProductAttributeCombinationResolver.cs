namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "ProductAttributeCombination")]
    public class ProductAttributeCombinationResolver
    {
        public Task<ProductAttributeCombination> GetProductAttributeCombinationAsync([Parent] ProductVariation productVariation, [Service] IProductAttributeCombinationRepository dataRepository)
        {
            if (productVariation != null && productVariation.ProductAttributeCombinationId != null)
            {
                return dataRepository.GetByIdAsync(productVariation.ProductAttributeCombinationId);
            }
            else
            {
                return null;
            }
        }
    }
}
