using System;
using System.Collections.Generic;
using GraphQL.Core.Enums;

namespace GraphQL.Core.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerId, Address shippingAddress, DeliveryMethod deliveryMethod, double subTotal, string paymentIntentId)
        {
            BuyerId = buyerId;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            SubTotal = subTotal;
            PaymentIntentId = paymentIntentId;
        }

        public string BuyerId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public double SubTotal { get; set; }
        public double Tax { get; set; }
        public double Discount { get; set; }
        public double PaidTotal { get; set; }
        public double RefundTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public IReadOnlyList<Coupon> Coupons { get; set; }
        //public IReadOnlyList<Refund> Refunds { get; set; }
        public string PaymentIntentId { get; set; }

        public double GetTotal(){
            return SubTotal + DeliveryMethod.Charge;
        }
    }
}