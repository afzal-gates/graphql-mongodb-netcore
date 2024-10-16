namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class AssetItemRepository : BaseRepository<AssetItem>, IAssetItemRepository
    {
        public AssetItemRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
