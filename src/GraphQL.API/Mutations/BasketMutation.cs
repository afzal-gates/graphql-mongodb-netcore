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
    public class BasketMutation
    {

        public async Task<Basket> CreateBasketAsync(Basket Basket, [Service] IBasketRepository BasketRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BasketRepository.InsertAsync(Basket);
            //await eventSender.SendAsync(nameof(Subscriptions.BasketSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<Basket>> CreateBasketsAsync(IEnumerable<Basket> Baskets, [Service] IBasketRepository BasketRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BasketRepository.InsertRangeAsync(Baskets);
            //await eventSender.SendAsync(nameof(Subscriptions.BasketSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Basket> UpdateBasketAsync(Basket Basket, [Service] IBasketRepository BasketRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BasketRepository.UpdateAsync(Basket);
            //await eventSender.SendAsync(nameof(Subscriptions.BasketSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveBasketAsync(string id, [Service] IBasketRepository BasketRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BasketRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.BasketSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] IBasketRepository BasketRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await BasketRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await BasketRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.BasketSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
