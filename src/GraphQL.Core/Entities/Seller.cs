
using System.Collections.Generic;

namespace GraphQL.Core.Entities
{
    public class Seller : BasicUserInfo
    {
        public List<string> AddressIds { get; set; }
    }
}