namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "ProductTag")]
    public class ProductTagResolver
    {
        public Task<ICollection<ProductTag>> GetProductTagsAsync([Parent] Product product, [Service] IProductTagRepository dataRepository) =>
            dataRepository.FindAllAsync(x => x.Id == product.Id);
    }
}
