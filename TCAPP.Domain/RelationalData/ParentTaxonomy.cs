using System;
using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class ParentTaxonomy
    {
        public Guid IdTaxonomy { get; set; }
        public Guid IdParentTaxonomy { get; set; }
        public Taxonomy Taxonomy { get; set; }
        public Taxonomy Parent { get; set; }
    }
}
