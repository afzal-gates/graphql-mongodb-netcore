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
    public class CouponMutation
    {

        public async Task<Coupon> CreateCouponAsync(Coupon Coupon, [Service] ICouponRepository CouponRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await CouponRepository.InsertAsync(Coupon);
            //await eventSender.SendAsync(nameof(Subscriptions.CouponSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<Coupon>> CreateCouponsAsync(IEnumerable<Coupon> Coupons, [Service] ICouponRepository CouponRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await CouponRepository.InsertRangeAsync(Coupons);
            //await eventSender.SendAsync(nameof(Subscriptions.CouponSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Coupon> UpdateCouponAsync(Coupon Coupon, [Service] ICouponRepository CouponRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await CouponRepository.UpdateAsync(Coupon);
            //await eventSender.SendAsync(nameof(Subscriptions.CouponSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveCouponAsync(string id, [Service] ICouponRepository CouponRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await CouponRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.CouponSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] ICouponRepository CouponRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await CouponRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await CouponRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.CouponSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
