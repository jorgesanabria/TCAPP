using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class ContentTaxonomy
    {
        public long IdContent { get; set; }
        public long IdTaxonomy { get; set; }
        public Content Content { get; set; }
        public Taxonomy Taxonomy { get; set; }
    }
}
