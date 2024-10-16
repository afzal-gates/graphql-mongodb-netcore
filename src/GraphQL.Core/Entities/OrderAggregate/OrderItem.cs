using GraphQL.Core.Enums;

namespace GraphQL.Core.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, double price, int quantity, double tax, double discount, OrderItemStatus orderItemStatus = OrderItemStatus.OrderPlaced)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
            Tax = tax;
            Discount = discount;
            OrderItemStatus = orderItemStatus;
        }
        public string OrderId {  get; set; }
        public ProductItemOrdered ItemOrdered { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
        public OrderItemStatus OrderItemStatus { get; set; } = OrderItemStatus.OrderPlaced;
    }
}