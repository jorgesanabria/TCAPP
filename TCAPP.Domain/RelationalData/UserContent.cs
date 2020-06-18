using System;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class UserContent
    {
        public Guid IdUser { get; set; }
        public Guid IdContent { get; set; }
        public long IdContentRelationType { get; set; }
        public User User { get; set; }
        public Content Content { get; set; }
        public ContentRelationType ContentRelationType { get; set; }
    }
}
