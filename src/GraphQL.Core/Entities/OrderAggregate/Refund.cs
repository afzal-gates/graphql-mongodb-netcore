using System.Collections.Generic;

namespace GraphQL.Core.Entities
{
    public class Refund : BaseEntity
    {
        public Refund() { }
        public Refund(IReadOnlyList<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }

        public string Reason { get; set; }
        public double Amount { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
    }
}