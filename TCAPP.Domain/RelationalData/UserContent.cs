using System;
using System.Collections.Generic;
using System.Text;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.TypeData;

namespace TCAPP.Domain.RelationalData
{
    public class UserContent
    {
        public decimal IdUser { get; set; }
        public decimal IdContent { get; set; }
        public decimal IdContentRelationType { get; set; }
        public decimal? IdCollection { get; set; }
        public User User { get; set; }
        public Content Content { get; set; }
        public ContentRelationType ContentRelationType { get; set; }
        public Collection Collection { get; set; }
    }
}
