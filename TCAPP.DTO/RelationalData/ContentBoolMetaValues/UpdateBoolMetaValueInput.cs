using System;

namespace TCAPP.DTO.RelationalData.ContentBoolMetaValues
{
    public class UpdateBoolMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public bool? Value { get; set; }
        public bool? Enabled { get; set; }
    }
}
