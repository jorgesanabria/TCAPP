using System;

namespace TCAPP.DTO.RelationalData.ContentFloatMetaValues
{
    public class CreateFloatMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public float Value { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
    }
}
