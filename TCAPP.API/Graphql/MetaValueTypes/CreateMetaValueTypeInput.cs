namespace TCAPP.API.Graphql.MetaValueTypes
{
    public class CreateMetaValueTypeInput
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }
    }
}
