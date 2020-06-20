using System;

namespace TCAPP.TypeData.ContentRelationTypes
{
    public class UpdateContentRelationTypeInput
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? Updated { get; set; }
        public bool? Enabled { get; set; }
    }
}
