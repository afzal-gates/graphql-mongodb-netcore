namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class BuyerRepository : BaseRepository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
