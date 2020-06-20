using System;

namespace TCAPP.DTO.ConcreteData.Contents
{
    public class UpdateContentInput
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public long? IdContentType { get; set; }
        public bool? Enabled { get; set; }
    }
}
