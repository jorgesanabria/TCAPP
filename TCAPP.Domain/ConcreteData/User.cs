﻿using HotChocolate;
using System;
using System.Collections.Generic;
using TCAPP.Domain.RelationalData;

namespace TCAPP.Domain.ConcreteData
{
    public class User
    {
        public User()
        {
            UserContents = new HashSet<UserContent>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [GraphQLIgnore]
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public ICollection<UserContent> UserContents { get; set; }
    }
}
