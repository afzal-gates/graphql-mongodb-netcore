namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class BuyerType : ObjectType<Buyer>
    {
        protected override void Configure(IObjectTypeDescriptor<Buyer> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.FirstName);
            descriptor.Field(_ => _.LastName);
            descriptor.Field(_ => _.DisplayName);
            descriptor.Field(_ => _.Email);
            descriptor.Field(_ => _.Phone);
            descriptor.Field(_ => _.UserGroup);
            descriptor.Field(_ => _.AddressIds);
            descriptor.Field<AddressResolver>(_ => _.GetAddressByBuyerAsync(default, default));
        }
    }
}
