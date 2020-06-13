using System;
using System.Collections.Generic;

namespace TCAPP.Domain.ConcreteData
{
    public class Image
    {
        public Image()
        {
            Contents = new HashSet<Content>();
        }
        public decimal Id { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
