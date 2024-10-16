using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Core.Entities
{
    public class ProductTag : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }

    }
}