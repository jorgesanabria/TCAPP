using System;

namespace TCAPP.API.Graphql.Taxonomies
{
    public class UpdateTaxonomyInput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool? Multiple { get; set; }
        public bool? Enabled { get; set; }
    }
}
