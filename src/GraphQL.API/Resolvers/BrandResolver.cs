namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Brand")]
    public class BrandResolver
    {
        public Task<Brand> GetBrandAsync([Parent] Product product, [Service] IBrandRepository dataRepository) =>
            dataRepository.GetByIdAsync(product.BrandId);        
    }
}
