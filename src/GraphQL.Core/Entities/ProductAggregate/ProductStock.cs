using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Core.Entities
{
    public class ProductStock: BaseEntity
    {
        public string ProductId {  get; set; }
        public string ProductVariationId {  get; set; }
        public string MeasurementUnitId {  get; set; }
        public double InHouseQty { get; set; } = 0;
        public double SoldQty {  get; set; } = 0;
        public double DamageQty {  get; set; } = 0;
        public double StockQty {  get; set; } = 0;
    }
}
