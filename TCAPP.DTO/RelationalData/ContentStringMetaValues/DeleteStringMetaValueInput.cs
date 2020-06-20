using System;

namespace TCAPP.DTO.RelationalData.ContentStringMetaValues
{
    public class DeleteStringMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
    }
}
