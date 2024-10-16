
using System.Collections.Generic;

namespace GraphQL.Core.Entities
{
    public class Buyer : BasicUserInfo
    {
        public List<string> AddressIds { get; set; }
    }
}