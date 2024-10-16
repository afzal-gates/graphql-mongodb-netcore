namespace GraphQL.API.Queries
{
    using GraphQL.API.Extensions;
    using GraphQL.API.Filters;
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Data;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Query")]

    //[Cached(600)]
    public class ProductQuery
    {
        [UsePaging]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering(typeof(ProductFilterType))]
        [UseSorting]

        //[Cached(600)]
        public Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) =>
            productRepository.GetAllAsync();


        [UsePaging]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering(typeof(ProductFilterType))]
        [UseSorting]
        public async Task<IEnumerable<Product>> GetQueryProductsAsync(int qty, double price, [Service] IProductRepository productRepository)
        {
            IEnumerable<Product> products = await productRepository.FindAllAsync(x => x.Quantity > qty && x.ActualPrice >= price);
            return products;
        }


        public Task<Product> GetProductAsync(string id, [Service] IProductRepository productRepository) =>
            productRepository.GetByIdAsync(id);
    }
}
