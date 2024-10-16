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
    public class AssetMutation
    {

        public async Task<AssetItem> CreateAssetItemAsync(AssetItem AssetItem, [Service] IAssetItemRepository AssetItemRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await AssetItemRepository.InsertAsync(AssetItem);
            //await eventSender.SendAsync(nameof(Subscriptions.AssetItemSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<AssetItem>> CreateAssetItemsAsync(IEnumerable<AssetItem> AssetItems, [Service] IAssetItemRepository AssetItemRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await AssetItemRepository.InsertRangeAsync(AssetItems);
            //await eventSender.SendAsync(nameof(Subscriptions.AssetItemSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<AssetItem> UpdateAssetItemAsync(AssetItem AssetItem, [Service] IAssetItemRepository AssetItemRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await AssetItemRepository.UpdateAsync(AssetItem);
            //await eventSender.SendAsync(nameof(Subscriptions.AssetItemSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveAssetItemAsync(string id, [Service] IAssetItemRepository AssetItemRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await AssetItemRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.AssetItemSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] IAssetItemRepository AssetItemRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await AssetItemRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await AssetItemRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.AssetItemSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
