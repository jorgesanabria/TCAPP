using System;

namespace TCAPP.DTO.RelationalData.ParentContents
{
    public class CreateOrDeleteParentInput
    {
        public Guid IdParent { get; set; }
        public Guid IdContent { get; set; }
    }
}
