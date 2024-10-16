namespace GraphQL.API.Mutations
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Subscriptions;
    using HotChocolate.Types;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Mutation")]
    public class BrandMutation
    {

        public async Task<Brand> CreateBrandAsync(Brand brand, [Service] IBrandRepository BrandRepository, [Service] ITopicEventSender eventSender)
        {
            if (brand.CreatedAt == null)
                brand.CreatedAt = DateTime.UtcNow;
            var result = await BrandRepository.InsertAsync(brand);
            //await eventSender.SendAsync(nameof(Subscriptions.BrandSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<IEnumerable<Brand>> CreateBrandsAsync(IEnumerable<Brand> brands, [Service] IBrandRepository BrandRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BrandRepository.InsertRangeAsync(brands);
            //await eventSender.SendAsync(nameof(Subscriptions.BrandSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<Brand> UpdateBrandAsync(Brand brand, [Service] IBrandRepository BrandRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BrandRepository.UpdateAsync(brand);
            //await eventSender.SendAsync(nameof(Subscriptions.BrandSubscriptions.OnCreateAsync), result);
            return result;
        }

        public async Task<bool> RemoveBrandAsync(string id, [Service] IBrandRepository BrandRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await BrandRepository.RemoveAsync(id);
            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.BrandSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }

        public async Task<bool> RemoveCategoriesAsync(string[] ids, [Service] IBrandRepository BrandRepository, [Service] ITopicEventSender eventSender)
        {
            var categories = await BrandRepository.FindAllAsync(x => ids.Contains(x.Id));
            var result = await BrandRepository.RemoveRangeAsync(categories);

            //if (result)
            //{
            //    await eventSender.SendAsync(nameof(Subscriptions.BrandSubscriptions.OnRemoveAsync), id);
            //}
            return result;
        }
    }
}
