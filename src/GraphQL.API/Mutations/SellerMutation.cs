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
    public class SellerMutation
    {

        public async Task<Seller> CreateSellerAsync(Seller Seller, [Service] ISellerRepository SellerRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await SellerRepository.InsertAsync(Seller);
            //await eventSender.SendAsync(nameof(Subscriptions.SellerSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<Seller>> CreateSellersAsync(IEnumerable<Seller> Sellers, [Service] ISellerRepository SellerRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await SellerRepository.InsertRangeAsync(Sellers);
            //await eventSender.SendAsync(nameof(Subscriptions.SellerSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Seller> UpdateSellerAsync(Seller Seller, [Service] ISellerRepository SellerRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await SellerRepository.UpdateAsync(Seller);
            //await eventSender.SendAsync(nameof(Subscriptions.SellerSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveSellerAsync(string id, [Service] ISellerRepository SellerRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await SellerRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.SellerSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] ISellerRepository SellerRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await SellerRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await SellerRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.SellerSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
