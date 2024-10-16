namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class CouponRepository : BaseRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
