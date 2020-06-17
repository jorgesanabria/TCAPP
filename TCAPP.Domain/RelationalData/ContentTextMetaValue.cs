using System;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class ContentTextMetaValue
    {
        public long IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public string Value { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public Content Content { get; set; }
        public MetaValueType MetaValueType { get; set; }
    }
}
