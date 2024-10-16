namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
