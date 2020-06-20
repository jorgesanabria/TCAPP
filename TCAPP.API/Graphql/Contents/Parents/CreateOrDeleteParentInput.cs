using System;

namespace TCAPP.API.Graphql.Contents.Parents
{
    public class CreateOrDeleteParentInput
    {
        public Guid IdParent { get; set; }
        public Guid IdContent { get; set; }
    }
}
