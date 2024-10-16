using System.Collections.Generic;

namespace GraphQL.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public List<string> ParentCategoryIds { get; set; }
    }
}
