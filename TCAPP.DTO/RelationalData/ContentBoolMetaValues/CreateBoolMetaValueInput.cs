using System;

namespace TCAPP.DTO.RelationalData.ContentBoolMetaValues
{
    public class CreateBoolMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public bool Value { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
    }
}
