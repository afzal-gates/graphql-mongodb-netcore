namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class ProductVariationRepository : BaseRepository<ProductVariation>, IProductVariationRepository
    {
        public ProductVariationRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
