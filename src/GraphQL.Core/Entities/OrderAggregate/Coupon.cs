namespace GraphQL.Core.Entities
{
    public class Coupon : BaseEntity
    {
        public string Code { get; set; }
        public double Percent { get; set; }
        public double Amount { get; set; }
    }
}