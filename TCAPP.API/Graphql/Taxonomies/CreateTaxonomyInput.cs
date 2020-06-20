using System;
using System.Collections.Generic;

namespace TCAPP.API.Graphql.Taxonomies
{
    public class CreateTaxonomyInput
    {
        public CreateTaxonomyInput()
        {
            ParentTaxonomies = new List<CreateTaxonomyInput>();
            ChildrenTaxonomies = new List<CreateTaxonomyInput>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public bool Multiple { get; set; }
        public List<CreateTaxonomyInput> ParentTaxonomies { get; set; }
        public List<CreateTaxonomyInput> ChildrenTaxonomies { get; set; }
    }
}
