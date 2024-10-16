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
    public class OrderMutation
    {

        public async Task<Order> CreateOrderAsync(Order Order, [Service] IOrderRepository OrderRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await OrderRepository.InsertAsync(Order);
            //await eventSender.SendAsync(nameof(Subscriptions.OrderSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<Order>> CreateOrdersAsync(IEnumerable<Order> Orders, [Service] IOrderRepository OrderRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await OrderRepository.InsertRangeAsync(Orders);
            //await eventSender.SendAsync(nameof(Subscriptions.OrderSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Order> UpdateOrderAsync(Order Order, [Service] IOrderRepository OrderRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await OrderRepository.UpdateAsync(Order);
            //await eventSender.SendAsync(nameof(Subscriptions.OrderSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveOrderAsync(string id, [Service] IOrderRepository OrderRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await OrderRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.OrderSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] IOrderRepository OrderRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await OrderRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await OrderRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.OrderSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
