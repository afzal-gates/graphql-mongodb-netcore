namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "ProductAttributeValue")]
    public class ProductAttributeValueResolver
    {
        public Task<ICollection<ProductAttributeValue>> GetProductAttributeValueByIdAsync([Parent] ProductAttribute productAtt, [Service] IProductAttributeValueRepository dataRepository) =>
            dataRepository.FindAllAsync(x => x.ProductAttributeId == productAtt.Id);
        public Task<ICollection<ProductAttributeValue>> GetProductAttributeValueByIdsAsync([Parent] ProductAttributeCombination productAttcomb, [Service] IProductAttributeValueRepository dataRepository)
        {
            if (productAttcomb == null)
                return null;
            if (productAttcomb.ProductAttributeValueIds == null || productAttcomb.ProductAttributeValueIds.Count() == 0)
                productAttcomb.ProductAttributeValueIds.Add("-1");
            return dataRepository.GetByIdsAsync(productAttcomb.ProductAttributeValueIds);

        }
    }
}
