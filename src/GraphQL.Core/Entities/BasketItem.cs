namespace GraphQL.Core.Entities
{
    public class BasketItem : BaseEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSku { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string BrandId { get; set; }
        public string ProductCustomTypeId { get; set; }
    }
}