namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class ProductStockRepository : BaseRepository<ProductStock>, IProductStockRepository
    {
        public ProductStockRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
