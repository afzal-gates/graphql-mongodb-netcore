
using System.Collections.Generic;

namespace GraphQL.Core.Entities
{
    public class Supplier : BasicUserInfo
    {
        public List<string> AddressIds { get; set; }
    }
}