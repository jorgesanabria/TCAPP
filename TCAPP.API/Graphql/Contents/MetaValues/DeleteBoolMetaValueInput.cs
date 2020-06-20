using System;

namespace TCAPP.API.Graphql.Contents.MetaValues
{
    public class DeleteBoolMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
    }
}
