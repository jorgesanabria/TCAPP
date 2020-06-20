using System;

namespace TCAPP.API.Graphql.Contents.MetaValues
{
    public class DeleteStringMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
    }
}
