using System;

namespace TCAPP.DTO.RelationalData.ContentBoolMetaValues
{
    public class DeleteBoolMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
    }
}
