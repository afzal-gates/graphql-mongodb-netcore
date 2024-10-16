namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class BasketItemRepository : BaseRepository<BasketItem>, IBasketItemRepository
    {
        public BasketItemRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
