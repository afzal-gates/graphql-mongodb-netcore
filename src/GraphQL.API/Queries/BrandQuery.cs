namespace GraphQL.API.Queries
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.AspNetCore.Authorization;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Query")]
    public class BrandQuery
    {
        public Task<IEnumerable<Brand>> GetBrandsAsync([Service] IBrandRepository brandRepository) =>
            brandRepository.GetAllAsync();

        //[Authorize]
        public Task<Brand> GetBrandAsync(string id, [Service] IBrandRepository brandRepository) =>
            brandRepository.GetByIdAsync(id);
        // Create methods
    }
}
