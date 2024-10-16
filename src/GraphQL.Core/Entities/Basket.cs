using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Core.Entities
{
    public class Basket : BaseEntity
    {
        public Basket()
        {

        }
        public Basket(string id)
        {
            Id = id;
        }
        public string BuyerId { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

        //public string DeliveryMethodId { get; set; }
        //public string ClientSecret { get; set; }
        //public string PaymentIntentId { get; set; }
        //public double ShippingPrice { get; set; }
    }
}
