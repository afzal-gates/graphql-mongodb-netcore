namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Category")]
    public class CategoryResolver
    {
        public Task<Category> GetCategoryAsync([Parent] Product product, [Service] ICategoryRepository dataRepository) =>
            dataRepository.GetByIdAsync(product.CategoryId);
        public Task<ICollection<Category>> GetCategoriesAsync([Parent] Product product, [Service] ICategoryRepository dataRepository)
        {
            if (product.CategoryIds != null && product.CategoryIds.Count() > 0)
            {
               return dataRepository.GetByIdsAsync(product.CategoryIds);
            }
            else
            {
                return null;
            }
        }

        public Task<ICollection<Category>> GetParentCategoriesAsync([Parent] Category cat, [Service] ICategoryRepository dataRepository)
        {
            if (cat.ParentCategoryIds != null && cat.ParentCategoryIds.Count() > 0)
            {
                return dataRepository.GetByIdsAsync(cat.ParentCategoryIds);
            }
            else
            {
                return null;
            }
        }
    }
}
