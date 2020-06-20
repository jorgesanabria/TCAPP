using System;

namespace TCAPP.API.Graphql.MetaValueTypes
{
    public class UpdateMetaValueTypeInput
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }
    }
}
