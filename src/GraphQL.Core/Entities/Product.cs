namespace GraphQL.Core.Entities
{
    public class ProductOld : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryId { get; set; }
    }
}
