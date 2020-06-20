using System;

namespace TCAPP.DTO.RelationalData.ContentStringMetaValues
{
    public class UpdateStringMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public string Value { get; set; }
        public bool? Enabled { get; set; }
    }
}
