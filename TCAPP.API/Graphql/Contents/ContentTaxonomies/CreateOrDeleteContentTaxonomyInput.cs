using System;

namespace TCAPP.API.Graphql.Contents.ContentTaxonomies
{
    public class CreateOrDeleteContentTaxonomyInput
    {
        public Guid IdContent { get; set; }
        public Guid IdTaxonomy { get; set; }
    }
}
