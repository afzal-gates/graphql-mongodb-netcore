namespace GraphQL.Core.Entities
{
    public class DeliveryMethod : BaseEntity
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public double Charge { get; set; }
    }
}