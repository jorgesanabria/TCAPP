using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class ContentTaxonomy
    {
        public decimal IdContent { get; set; }
        public decimal IdTaxonomy { get; set; }
        public Content Content { get; set; }
        public Taxonomy Taxonomy { get; set; }
    }
}
