namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "ProductAttribute")]
    public class ProductAttributeResolver
    {
        public Task<ICollection<ProductAttribute>> GetProductAttributeAsync([Parent] ProductAttributeValue productAtt, [Service] IProductAttributeRepository dataRepository)
        {
            if (productAtt == null)
                return null;
            return dataRepository.FindAllAsync(x => x.Id == productAtt.ProductAttributeId);
        }
        public Task<ICollection<ProductAttribute>> GetProductAttributesAsync([Parent] Product product, [Service] IProductAttributeRepository dataRepository) =>
            dataRepository.FindAllAsync(x => x.ProductId == product.Id);
    }
}
