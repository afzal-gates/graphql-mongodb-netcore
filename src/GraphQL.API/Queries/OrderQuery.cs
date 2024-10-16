namespace GraphQL.API.Queries
{
    using GraphQL.API.Filters;
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using GraphQL.Infrastructure.Repositories;
    using HotChocolate;
    using HotChocolate.AspNetCore.Authorization;
    using HotChocolate.Data;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Query")]
    public class OrderQuery
    {
        [UsePaging]
        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering(typeof(ProductFilterType))]
        [UseSorting]
        public Task<IEnumerable<Order>> GetOrdersAsync([Service] IOrderRepository orderRepository) =>
            orderRepository.GetAllAsync();

        //[Authorize]
        public Task<Order> GetOrderAsync(string id, [Service] IOrderRepository orderRepository) =>
            orderRepository.GetByIdAsync(id);
        // Create methods


        public Task<ICollection<OrderItem>> GetOrderItemsAsync(string orderId, [Service] IOrderItemRepository supplierRepository) =>
            supplierRepository.FindAllAsync(x => x.OrderId == orderId);
    }
}
