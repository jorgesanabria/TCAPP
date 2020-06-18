using System;

namespace TCAPP.API.Graphql.Contents.MetaValues
{
    public class CreateTextMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public string Value { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
    }
}
