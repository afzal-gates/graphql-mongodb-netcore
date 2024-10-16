namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class ProductAttributeCombinationRepository : BaseRepository<ProductAttributeCombination>, IProductAttributeCombinationRepository
    {
        public ProductAttributeCombinationRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
