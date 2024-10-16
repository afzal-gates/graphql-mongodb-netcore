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
    public class AssetQuery
    {
        [UsePaging]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering(typeof(ProductFilterType))]
        [UseSorting]
        public Task<IEnumerable<AssetItem>> GetAssetsAsync([Service] IAssetItemRepository assetRepository) =>
            assetRepository.GetAllAsync();

        //[Authorize]
        public Task<AssetItem> GetAssetAsync(string id, [Service] IAssetItemRepository assetRepository) =>
            assetRepository.GetByIdAsync(id);
        // Create methods
    }
}
