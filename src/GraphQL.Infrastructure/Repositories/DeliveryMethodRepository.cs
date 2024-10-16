namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class DeliveryMethodRepository : BaseRepository<DeliveryMethod>, IDeliveryMethodRepository
    {
        public DeliveryMethodRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
