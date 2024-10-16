namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class ProductVariationType : ObjectType<ProductVariation>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductVariation> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.Name);
            descriptor.Field(_ => _.Sku);
            descriptor.Field(_ => _.ModelNo);
            descriptor.Field(_ => _.Description);
            descriptor.Field(_ => _.Summary);
            descriptor.Field(_ => _.BasePrice);
            descriptor.Field(_ => _.SalePrice);
            descriptor.Field(_ => _.CostPrice);
            descriptor.Field(_ => _.Quantity);
            descriptor.Field(_ => _.AssetImageId);
            descriptor.Field(_ => _.AssetImageIds);
            descriptor.Field(_ => _.ProductAttributeCombinationId);
            descriptor.Field<AssetImageResolver>(_ => _.GetAssetImageAsync(default, default));
            descriptor.Field<AssetImageResolver>(_ => _.GetAssetImagesAsync(default, default));
            descriptor.Field<ProductAttributeCombinationResolver>(_ => _.GetProductAttributeCombinationAsync(default, default));
        }
    }
}
