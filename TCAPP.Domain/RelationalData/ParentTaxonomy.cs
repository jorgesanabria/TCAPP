using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class ParentTaxonomy
    {
        public decimal IdTaxonomy { get; set; }
        public decimal IdParentTaxonomy { get; set; }
        public Taxonomy Taxonomy { get; set; }
        public Taxonomy Parent { get; set; }
    }
}
