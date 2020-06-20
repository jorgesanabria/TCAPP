using System;
using System.Collections.Generic;
using TCAPP.API.Graphql.Contents.ContentTaxonomies;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Parents;
using TCAPP.API.Graphql.Contents.UserContents;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents
{
    public class CreateContentInput
    {
        public CreateContentInput()
        {
            Parents = new List<CreateOrDeleteParentInput>();
            Children = new List<CreateContentInput>();
            Texts = new List<CreateTextMetaValueInput>();
            Strings = new List<CreateStringMetaValueInput>();
            Bools = new List<CreateBoolMetaValueInput>();
            Floats = new List<CreateFloatMetaValueInput>();
            UserContents = new List<CreateOrDeleteUserContentInput>();
            ContentTaxonomies = new List<CreateOrDeleteContentTaxonomyInput>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public long IdContentType { get; set; }
        public DateTime? Created { get; set; }
        public bool Enabled { get; set; }
        public Content Content { get; set; }
        public List<CreateOrDeleteParentInput> Parents { get; set; }
        public List<CreateContentInput> Children { get; set; }
        public List<CreateTextMetaValueInput> Texts { get; set; }
        public List<CreateStringMetaValueInput> Strings { get; set; }
        public List<CreateBoolMetaValueInput> Bools { get; set; }
        public List<CreateFloatMetaValueInput> Floats { get; set; }
        public List<CreateOrDeleteUserContentInput> UserContents { get; set; }
        public List<CreateOrDeleteContentTaxonomyInput> ContentTaxonomies { get; set; }
    }
}
