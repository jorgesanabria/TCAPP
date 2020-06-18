using System;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.Domain.RelationalData
{
    public class ParentContent
    {
        public Guid IdContent { get; set; }
        public Guid IdParentContent { get; set; }
        public Content Content { get; set; }
        public Content Parent { get; set; }
    }
}
