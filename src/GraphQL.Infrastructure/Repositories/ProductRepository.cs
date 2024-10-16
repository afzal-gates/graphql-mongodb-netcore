namespace GraphQL.Infrastructure.Repositories
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Data;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IMongoCollection<Product> collection;
        public ProductRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
            if (catalogContext == null)
            {
                throw new ArgumentNullException(nameof(catalogContext));
            }

            this.collection = catalogContext.GetCollection<Product>(typeof(Product).Name);
        }

        public async Task<IEnumerable<Product>> FindAllAsync(int qty)
        {
            return await this.collection.Find(_ => _.Quantity == qty).ToListAsync();
        }

        public Task<Product> FindAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
