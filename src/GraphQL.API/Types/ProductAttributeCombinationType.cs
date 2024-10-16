namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class ProductAttributeCombinationType : ObjectType<ProductAttributeCombination>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductAttributeCombination> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.ProductAttributeValueIds);
            descriptor.Field(_ => _.ProductId);
            descriptor.Field(_ => _.Combination);
            descriptor.Field<ProductAttributeValueResolver>(_ => _.GetProductAttributeValueByIdsAsync(default, default));
        }
    }
}
