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
    public class SellerQuery
    {
        [UsePaging]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering(typeof(ProductFilterType))]
        [UseSorting]
        public Task<IEnumerable<Seller>> GetSellersAsync([Service] ISellerRepository sellerRepository) =>
            sellerRepository.GetAllAsync();

        //[Authorize]
        public Task<Seller> GetSellerAsync(string id, [Service] ISellerRepository sellerRepository) =>
            sellerRepository.GetByIdAsync(id);
        // Create methods
    }
}
