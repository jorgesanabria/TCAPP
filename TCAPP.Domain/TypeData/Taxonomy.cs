using System;
using System.Collections.Generic;
using TCAPP.Domain.RelationalData;

namespace TCAPP.Domain.TypeData
{
    public class Taxonomy
    {
        public Taxonomy()
        {
            ParentTaxonomies = new HashSet<ParentTaxonomy>();
            ContentTaxonomies = new HashSet<ContentTaxonomy>();
            ChildrenTaxonomies = new HashSet<ParentTaxonomy>();
        }
        public decimal Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public bool Multiple { get; set; }
        public ICollection<ParentTaxonomy> ParentTaxonomies { get; set; }
        public ICollection<ParentTaxonomy> ChildrenTaxonomies { get; set; }
        public ICollection<ContentTaxonomy> ContentTaxonomies { get; set; }
    }
}
