using System;

namespace TCAPP.DTO.TypeData.Taxonomies
{
    public class CreateOrDeleteParentTaxonomyInput
    {
        public Guid IdParent { get; set; }
        public Guid IdTaxonomy { get; set; }
    }
}
