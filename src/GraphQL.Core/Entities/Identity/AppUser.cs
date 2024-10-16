﻿using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.AspNetCore.Identity;

namespace GraphQL.Core.Entities
{
    public class AppUser //: IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}
