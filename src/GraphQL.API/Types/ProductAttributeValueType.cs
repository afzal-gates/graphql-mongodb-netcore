namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class ProductAttributeValueType : ObjectType<ProductAttributeValue>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductAttributeValue> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.ProductAttributeId);
            descriptor.Field<ProductAttributeResolver>(_ => _.GetProductAttributeAsync(default, default));
        }
    }
}
