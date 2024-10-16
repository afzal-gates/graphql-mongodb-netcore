namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
