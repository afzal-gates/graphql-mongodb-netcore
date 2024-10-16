namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class ProductItemOrderedRepository : BaseRepository<ProductItemOrdered>, IProductItemOrderedRepository
    {
        public ProductItemOrderedRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
