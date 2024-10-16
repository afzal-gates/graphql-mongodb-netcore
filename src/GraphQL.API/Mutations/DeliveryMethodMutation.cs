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
    public class DeliveryMethodMutation
    {

        public async Task<DeliveryMethod> CreateDeliveryMethodAsync(DeliveryMethod DeliveryMethod, [Service] IDeliveryMethodRepository DeliveryMethodRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await DeliveryMethodRepository.InsertAsync(DeliveryMethod);
            //await eventSender.SendAsync(nameof(Subscriptions.DeliveryMethodSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<DeliveryMethod>> CreateDeliveryMethodsAsync(IEnumerable<DeliveryMethod> DeliveryMethods, [Service] IDeliveryMethodRepository DeliveryMethodRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await DeliveryMethodRepository.InsertRangeAsync(DeliveryMethods);
            //await eventSender.SendAsync(nameof(Subscriptions.DeliveryMethodSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<DeliveryMethod> UpdateDeliveryMethodAsync(DeliveryMethod DeliveryMethod, [Service] IDeliveryMethodRepository DeliveryMethodRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await DeliveryMethodRepository.UpdateAsync(DeliveryMethod);
            //await eventSender.SendAsync(nameof(Subscriptions.DeliveryMethodSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveDeliveryMethodAsync(string id, [Service] IDeliveryMethodRepository DeliveryMethodRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await DeliveryMethodRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.DeliveryMethodSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] IDeliveryMethodRepository DeliveryMethodRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await DeliveryMethodRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await DeliveryMethodRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.DeliveryMethodSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
