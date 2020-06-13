using System;
using System.Collections.Generic;
using TCAPP.Domain.RelationalData;

namespace TCAPP.Domain.ConcreteData
{
    public class Collection
    {
        public Collection()
        {
            UserContents = new HashSet<UserContent>();
        }
        public decimal Id { get; set; }
        public decimal IdUser { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public User User { get; set; }
        public ICollection<UserContent> UserContents { get; set; }
    }
}
