namespace GraphQL.Core.Entities
{
    public class ProductItemOrdered : BaseEntity
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(string productId, string productVariationId, string productName, string productSku, string imageUrl)
        {
            ProductId = productId;
            ProductVariationId = productVariationId;
            ProductName = productName;
            ProductSku = productSku;
            ImageUrl = imageUrl;
        }

        public string ProductId { get; set; }
        public string ProductVariationId { get; set; }
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public string ImageUrl { get; set; }
    }
}