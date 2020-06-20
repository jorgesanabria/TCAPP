namespace TCAPP.API.Graphql.ContentTypes
{
    public class UpdateContentTypeInput
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Enabled { get; set; }
    }
}
