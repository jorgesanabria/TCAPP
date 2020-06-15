using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class ParentTaxonomy
    {
        public long IdTaxonomy { get; set; }
        public long IdParentTaxonomy { get; set; }
        public Taxonomy Taxonomy { get; set; }
        public Taxonomy Parent { get; set; }
    }
}
