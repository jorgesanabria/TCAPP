using System;

namespace TCAPP.DTO.RelationalData.ContentTextMetaValues
{
    public class DeleteTextMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
    }
}
