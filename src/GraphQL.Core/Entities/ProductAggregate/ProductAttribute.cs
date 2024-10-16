using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Core.Entities
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }
        public int? SequenceValue { get; set; } = 1;
        public string ProductId { get; set; }
    }

    public class ProductAttributeValue : BaseEntity
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public int? SequenceValue { get; set; } = 1;
        public string ProductAttributeId { get; set; }
    }

    public class ProductAttributeCombination : BaseEntity
    {
        public string Combination { get; set; }
        public IList<string> ProductAttributeValueIds { get; set; }
        public int? SequenceValue { get; set; } = 1;
        public string ProductId { get; set; }
    }


    public class ProductAttributeViewModel : BaseEntity
    {
        public string Name { get; set; }
        public string ProductId { get; set; }
        public IList<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}