using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Core.Entities
{
    public class MeasurementUnit: BaseEntity
    {
        public string Title {  get; set; }
        public string Code {  get; set; }
        public string ConversionMeasurementUnitId {  get; set; }
        public double ConversionRate {  get; set; }
    }
}
