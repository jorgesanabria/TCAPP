﻿using System;

namespace TCAPP.DTO.ConcreteData.Users
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
