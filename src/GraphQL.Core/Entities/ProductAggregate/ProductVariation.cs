using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Core.Entities
{
    public class ProductVariation : BaseEntity
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public string ModelNo { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public double BasePrice { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        //public double ActualPrice { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public string ProductAttributeCombinationId {  get; set; }
        public string AssetImageId { get; set; }
        public IList<string> AssetImageIds { get; set; }
    }
}