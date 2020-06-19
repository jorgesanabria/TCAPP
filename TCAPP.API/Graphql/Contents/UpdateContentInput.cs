using System;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents
{
    public class UpdateContentInput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public long? IdContentType { get; set; }
        public bool? Enabled { get; set; }
        public Content Content { get; set; }
    }
}
