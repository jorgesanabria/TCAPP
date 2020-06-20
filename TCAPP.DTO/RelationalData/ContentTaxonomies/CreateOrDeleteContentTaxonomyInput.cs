using System;

namespace TCAPP.DTO.RelationalData.ContentTaxonomies
{
    public class CreateOrDeleteContentTaxonomyInput
    {
        public Guid IdContent { get; set; }
        public Guid IdTaxonomy { get; set; }
    }
}
