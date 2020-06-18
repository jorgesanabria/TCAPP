using System;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class ContentTaxonomy
    {
        public Guid IdContent { get; set; }
        public Guid IdTaxonomy { get; set; }
        public Content Content { get; set; }
        public Taxonomy Taxonomy { get; set; }
    }
}
