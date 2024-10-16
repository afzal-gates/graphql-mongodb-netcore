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
    public class RefundMutation
    {

        public async Task<Refund> CreateRefundAsync(Refund Refund, [Service] IRefundRepository RefundRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await RefundRepository.InsertAsync(Refund);
            //await eventSender.SendAsync(nameof(Subscriptions.RefundSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<Refund>> CreateRefundsAsync(IEnumerable<Refund> Refunds, [Service] IRefundRepository RefundRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await RefundRepository.InsertRangeAsync(Refunds);
            //await eventSender.SendAsync(nameof(Subscriptions.RefundSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Refund> UpdateRefundAsync(Refund Refund, [Service] IRefundRepository RefundRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await RefundRepository.UpdateAsync(Refund);
            //await eventSender.SendAsync(nameof(Subscriptions.RefundSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveRefundAsync(string id, [Service] IRefundRepository RefundRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await RefundRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.RefundSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] IRefundRepository RefundRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await RefundRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await RefundRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.RefundSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
