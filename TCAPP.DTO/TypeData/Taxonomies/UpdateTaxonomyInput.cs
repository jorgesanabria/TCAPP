using System;

namespace TCAPP.DTO.TypeData.Taxonomies
{
    public class UpdateTaxonomyInput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool? Multiple { get; set; }
        public bool? Enabled { get; set; }
    }
}
