namespace TCAPP.API.Graphql.Contents.MetaValues
{
    public class CreateFloatMetaValueInput
    {
        public long IdMetaValueType { get; set; }
        public float Value { get; set; }
        public bool Enabled { get; set; }
    }
}
