namespace GraphQL.API.Types
{
    using GraphQL.API.Resolvers;
    using GraphQL.Core.Entities;
    using HotChocolate.Types;

    public class AssetItemType : ObjectType<AssetItem>
    {
        protected override void Configure(IObjectTypeDescriptor<AssetItem> descriptor)
        {
            descriptor.Field(_ => _.Id);
            descriptor.Field(_ => _.Name);
            descriptor.Field(_ => _.Alt);
            descriptor.Field(_ => _.Url);
            descriptor.Field(_ => _.SmallUrl);
            descriptor.Field(_ => _.MediumUrl);
            descriptor.Field(_ => _.LargeUrl);
            descriptor.Field(_ => _.CreatedAt);
            descriptor.Field(_ => _.UpdatedAt);
            descriptor.Field(_ => _.IsVideo);
            descriptor.Field(_ => _.IsDeleted);
            //descriptor.Field<AssetImageResolver>(_ => _.GetAssetImageAsync(default, default));
        }
    }
}
