namespace GraphQL.API.Queries
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.AspNetCore.Authorization;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Query")]
    public class CategoryQuery
    {
        public Task<IEnumerable<Category>> GetCategoriesAsync([Service] ICategoryRepository categoryRepository) =>
            categoryRepository.GetAllAsync();

        //[Authorize]
        public Task<Category> GetCategoryAsync(string id, [Service] ICategoryRepository categoryRepository) =>
            categoryRepository.GetByIdAsync(id);
        // Create methods
    }
}
