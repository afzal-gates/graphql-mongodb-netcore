namespace GraphQL.API.Resolvers
{
    using GraphQL.Core.Entities;
    using GraphQL.Core.Repositories;
    using HotChocolate;
    using HotChocolate.Types;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ExtendObjectType(Name = "Image")]
    public class AssetImageResolver
    {
        public Task<AssetItem> GetAssetImageAsync([Parent] Product product, [Service] IAssetItemRepository dataRepository) =>
            dataRepository.GetByIdAsync(product.AssetImageId);

        public Task<ICollection<AssetItem>> GetAssetImagesAsync([Parent] Product product, [Service] IAssetItemRepository dataRepository)
        {
            if (product.AssetImageIds != null && product.AssetImageIds.Count() > 0)
            {
                return dataRepository.GetByIdsAsync(product.AssetImageIds);
            }
            else
            {
                return null;
            }
        }

        public Task<ICollection<AssetItem>> GetAssetVideosAsync([Parent] Product product, [Service] IAssetItemRepository dataRepository)
        {
            if (product.AssetVedioIds != null && product.AssetVedioIds.Count() > 0)
            {
                //return dataRepository.GetByIdsAsync(product.AssetImageIds);
                return dataRepository.FindAllAsync(x => product.AssetImageIds.Contains(x.Id) && x.IsVideo == true);
            }
            else
            {
                return null;
            }
        }
    }
}
