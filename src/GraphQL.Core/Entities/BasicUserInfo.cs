﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL.Core.Enums;

namespace GraphQL.Core.Entities
{
    public class BasicUserInfo : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserGroup UserGroup { get; set; }
        public string IdentityReferenceId {  get; set; }
    }
}
