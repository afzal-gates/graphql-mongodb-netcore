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
    public class BuyerMutation
    {

        public async Task<Buyer> CreateBuyerAsync(Buyer Buyer, [Service] IBuyerRepository BuyerRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BuyerRepository.InsertAsync(Buyer);
            //await eventSender.SendAsync(nameof(Subscriptions.BuyerSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<Buyer>> CreateBuyersAsync(IEnumerable<Buyer> Buyers, [Service] IBuyerRepository BuyerRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BuyerRepository.InsertRangeAsync(Buyers);
            //await eventSender.SendAsync(nameof(Subscriptions.BuyerSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Buyer> UpdateBuyerAsync(Buyer Buyer, [Service] IBuyerRepository BuyerRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BuyerRepository.UpdateAsync(Buyer);
            //await eventSender.SendAsync(nameof(Subscriptions.BuyerSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveBuyerAsync(string id, [Service] IBuyerRepository BuyerRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BuyerRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.BuyerSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] IBuyerRepository BuyerRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await BuyerRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await BuyerRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.BuyerSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
