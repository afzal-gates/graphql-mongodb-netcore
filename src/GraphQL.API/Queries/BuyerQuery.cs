namespace GraphQL.API.Queries
{
    using GraphQL.API.Filters;
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.AspNetCore.Authorization;
    using HotChocolate.Data;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Query")]
    public class BuyerQuery
    {
        [UsePaging]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering(typeof(ProductFilterType))]
        [UseSorting]
        public Task<IEnumerable<Buyer>> GetBuyersAsync([Service] IBuyerRepository buyerRepository) =>
            buyerRepository.GetAllAsync();

        //[Authorize]
        public Task<Buyer> GetBuyerAsync(string id, [Service] IBuyerRepository buyerRepository) =>
            buyerRepository.GetByIdAsync(id);
        // Create methods
    }
}
