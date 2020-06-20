using System;

namespace TCAPP.API.Graphql.Contents.MetaValues
{
    public class UpdateTextMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public string Value { get; set; }
        public bool? Enabled { get; set; }
    }
}
