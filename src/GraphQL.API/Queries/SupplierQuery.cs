namespace GraphQL.API.Queries
{
    using GraphQL.API.Filters;
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Repositories;
    using HotChocolate;
    using HotChocolate.AspNetCore.Authorization;
    using HotChocolate.Data;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Query")]
    public class SupplierQuery
    {
        [UsePaging]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering(typeof(ProductFilterType))]
        [UseSorting]
        public Task<IEnumerable<Supplier>> GetSuppliersAsync([Service] ISupplierRepository supplierRepository) =>
            supplierRepository.GetAllAsync();

        //[Authorize]
        public Task<Supplier> GetSupplierAsync(string id, [Service] ISupplierRepository supplierRepository) =>
            supplierRepository.GetByIdAsync(id);
        // Create methods
    }
}
