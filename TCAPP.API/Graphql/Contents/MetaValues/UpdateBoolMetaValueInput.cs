using System;

namespace TCAPP.API.Graphql.Contents.MetaValues
{
    public class UpdateBoolMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public bool? Value { get; set; }
        public bool? Enabled { get; set; }
    }
}
