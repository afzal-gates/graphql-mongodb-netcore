namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class ProductAttributeType : ObjectType<ProductAttribute>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductAttribute> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.ProductId);
            descriptor.Field<ProductAttributeValueResolver>(_ => _.GetProductAttributeValueByIdAsync(default, default));
        }
    }
}
