namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class RefundRepository : BaseRepository<Refund>, IRefundRepository
    {
        public RefundRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
