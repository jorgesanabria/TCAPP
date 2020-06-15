using System;
using System.Collections.Generic;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.Domain.TypeData
{
    public class ContentType
    {
        public ContentType()
        {
            Contents = new HashSet<Content>();
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
