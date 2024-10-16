namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.Name);
            descriptor.Field(_ => _.Sku);
            descriptor.Field(_ => _.Description);
            descriptor.Field(_ => _.Summary);
            descriptor.Field<CategoryResolver>(_ => _.GetParentCategoriesAsync(default, default));
        }
    }
}
