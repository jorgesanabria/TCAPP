﻿using System;

namespace TCAPP.API.Graphql.Users
{
    public class UpdateUserInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Enabled { get; set; }
    }
}
