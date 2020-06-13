using System;
using System.Collections.Generic;
using TCAPP.Domain.RelationalData;

namespace TCAPP.Domain.TypeData
{
    public class ContentRelationType
    {
        public ContentRelationType()
        {
            UserContents = new HashSet<UserContent>();
        }
        public decimal Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public ICollection<UserContent> UserContents { get; set; }
    }
}
