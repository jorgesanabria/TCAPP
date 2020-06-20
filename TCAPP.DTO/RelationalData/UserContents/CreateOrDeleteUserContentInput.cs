using System;

namespace TCAPP.DTO.RelationalData.UserContents
{
    public class CreateOrDeleteUserContentInput
    {
        public Guid IdUser { get; set; }
        public Guid IdContent { get; set; }
        public long IdContentRelationType { get; set; }
    }
}
