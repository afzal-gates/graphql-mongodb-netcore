namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
