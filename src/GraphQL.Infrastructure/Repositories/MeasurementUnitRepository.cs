namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;

    public class MeasurementUnitRepository : BaseRepository<MeasurementUnit>, IMeasurementUnitRepository
    {
        public MeasurementUnitRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
