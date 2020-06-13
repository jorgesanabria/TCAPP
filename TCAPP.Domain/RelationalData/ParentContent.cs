using TCAPP.Domain.ConcreteData;

namespace TCAPP.Domain.RelationalData
{
    public class ParentContent
    {
        public decimal IdContent { get; set; }
        public decimal IdParentContent { get; set; }
        public Content Content { get; set; }
        public Content Parent { get; set; }
    }
}
