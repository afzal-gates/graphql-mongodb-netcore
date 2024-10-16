namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class BasketType : ObjectType<Basket>
    {
        protected override void Configure(IObjectTypeDescriptor<Basket> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.BuyerId);
            descriptor.Field(_ =>_.BasketItems);
            descriptor.Field<BasketItemResolver>(_ => _.GetBasketItemAsync(default, default));
        }
    }
}
