using System;

namespace TCAPP.API.Graphql.Taxonomies
{
    public class CreaateOrDeleteParentTaxonomyInput
    {
        public Guid IdParent { get; set; }
        public Guid IdTaxonomy { get; set; }
    }
}
