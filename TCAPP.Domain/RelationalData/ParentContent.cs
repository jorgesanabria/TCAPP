using TCAPP.Domain.ConcreteData;

namespace TCAPP.Domain.RelationalData
{
    public class ParentContent
    {
        public long IdContent { get; set; }
        public long IdParentContent { get; set; }
        public Content Content { get; set; }
        public Content Parent { get; set; }
    }
}
