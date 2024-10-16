namespace GraphQL.Core.Repositories
{
    using GraphQL.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductRepository : IBaseRepository<Product>
    {
        //Task<IEnumerable<Product>> FindAllAsync(int id);
        //Task<Product> FindAsync(int id);
    }
}
