namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "BasketItem")]
    public class BasketItemResolver
    {
        public Task<BasketItem> GetBasketItemAsync([Parent] Basket busket, [Service] IBasketItemRepository dataRepository) =>
            dataRepository.GetByIdAsync(busket.Id);        
    }
}
