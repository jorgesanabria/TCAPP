using System;

namespace TCAPP.API.Graphql.ContentRelationTypes
{
    public class CreateContentRelationTypeInput
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
    }
}
