using System;

namespace TCAPP.API.Graphql.Contents.MetaValues
{
    public class UpdateFloatMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public float? Value { get; set; }
        public bool? Enabled { get; set; }
    }
}
