namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class ProductType : ObjectType<Product>
    {
        protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
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
            descriptor.Field(_ => _.ActualPrice);
            descriptor.Field(_ => _.Quantity);
            descriptor.Field(_ => _.CategoryId);
            descriptor.Field(_ => _.CategoryIds);
            descriptor.Field(_ => _.BrandId);
            descriptor.Field(_ => _.ProductCustomTypeId);
            descriptor.Field(_ => _.AssetImageId);
            descriptor.Field(_ => _.AssetImageIds);
            descriptor.Field(_ => _.AssetVedioIds);
            descriptor.Field(_ => _.IsNew);
            descriptor.Field(_ => _.IsFeatured);
            descriptor.Field(_ => _.IsOnSale);
            descriptor.Field(_ => _.IsSoldOut);
            descriptor.Field(_ => _.IsVariation);
            descriptor.Field(_ => _.IsStockEnabled);
            descriptor.Field(_ => _.ActualCreatedAt);
            descriptor.Field<CategoryResolver>(_ => _.GetCategoryAsync(default, default));
            descriptor.Field<CategoryResolver>(_ => _.GetCategoriesAsync(default, default));
            descriptor.Field<BrandResolver>(_ => _.GetBrandAsync(default, default));
            descriptor.Field<AssetImageResolver>(_ => _.GetAssetImageAsync(default, default));
            descriptor.Field<AssetImageResolver>(_ => _.GetAssetImagesAsync(default, default));
            descriptor.Field<AssetImageResolver>(_ => _.GetAssetVideosAsync(default, default));
            descriptor.Field<ProductTagResolver>(_ => _.GetProductTagsAsync(default, default));
            descriptor.Field<ProductAttributeResolver>(_ => _.GetProductAttributesAsync(default, default));
            descriptor.Field<ProductVariationResolver>(_ => _.GetProductVariationsAsync(default, default));
        }
    }
}
