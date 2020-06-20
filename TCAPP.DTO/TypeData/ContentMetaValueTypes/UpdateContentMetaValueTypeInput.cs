using System;

namespace TCAPP.TypeData.ContentMetaValueTypes
{
    public class UpdateContentMetaValueTypeInput
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }
    }
}
