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
            Collections = new HashSet<Collection>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public ICollection<UserContent> UserContents { get; set; }
        public ICollection<Collection> Collections { get; set; }
    }
}
