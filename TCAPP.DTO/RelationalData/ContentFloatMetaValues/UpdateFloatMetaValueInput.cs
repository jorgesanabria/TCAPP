using System;

namespace TCAPP.DTO.RelationalData.ContentFloatMetaValues
{
    public class UpdateFloatMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public float? Value { get; set; }
        public bool? Enabled { get; set; }
    }
}
