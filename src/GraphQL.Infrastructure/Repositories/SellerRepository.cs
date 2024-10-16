namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class SellerRepository : BaseRepository<Seller>, ISellerRepository
    {
        public SellerRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
