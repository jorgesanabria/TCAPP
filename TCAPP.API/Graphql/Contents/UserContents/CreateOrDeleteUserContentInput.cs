using System;

namespace TCAPP.API.Graphql.Contents.UserContents
{
    public class CreateOrDeleteUserContentInput
    {
        public Guid IdUser { get; set; }
        public Guid IdContent { get; set; }
        public long IdContentRelationType { get; set; }
    }
}
