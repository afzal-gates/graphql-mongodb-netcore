namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
