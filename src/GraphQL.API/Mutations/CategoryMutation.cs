namespace GraphQL.API.Mutations
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Subscriptions;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Mutation")]
    public class CategoryMutation
    {

        public async Task<Category> CreateCategoryAsync(Category category, [Service] ICategoryRepository CategoryRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await CategoryRepository.InsertAsync(category);
            //await eventSender.SendAsync(nameof(Subscriptions.CategorySubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<Category>> CreateCategoriesAsync(IEnumerable<Category> categories, [Service] ICategoryRepository CategoryRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await CategoryRepository.InsertRangeAsync(categories);
            //await eventSender.SendAsync(nameof(Subscriptions.CategorySubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Category> UpdateCategoryAsync(Category category, [Service] ICategoryRepository CategoryRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await CategoryRepository.UpdateAsync(category);
            //await eventSender.SendAsync(nameof(Subscriptions.CategorySubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveCategoryAsync(string id, [Service] ICategoryRepository CategoryRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await CategoryRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.CategorySubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] ICategoryRepository CategoryRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await CategoryRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await CategoryRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.CategorySubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
