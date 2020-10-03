using System;
using System.Collections.Generic;
using TCAPP.Domain.RelationalData;
using TCAPP.Domain.TypeData;
using HotChocolate.Types;

namespace TCAPP.Domain.ConcreteData
{
    public class Content
    {
        public Content()
        {
            ParentContents = new HashSet<ParentContent>();
            ChildrenContents = new HashSet<ParentContent>();
            UserContents = new HashSet<UserContent>();
            ContentTaxonomies = new HashSet<ContentTaxonomy>();
            ContentFloatMetaValues = new HashSet<ContentFloatMetaValue>();
            ContentStringMetaValues = new HashSet<ContentStringMetaValue>();
            ContentBoolMetaValues = new HashSet<ContentBoolMetaValue>();
            ContentTextMetaValues = new HashSet<ContentTextMetaValue>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public long IdContentType { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public ContentType ContentType { get; set; }
        [UseFiltering]
        public ICollection<ParentContent> ParentContents { get; set; }
        [UseFiltering]
        public ICollection<ParentContent> ChildrenContents { get; set; }
        [UseFiltering]
        public ICollection<UserContent> UserContents { get; set; }
        [UseFiltering]
        public ICollection<ContentTaxonomy> ContentTaxonomies { get; set; }
        [UseFiltering]
        public ICollection<ContentFloatMetaValue> ContentFloatMetaValues { get; set; }
        [UseFiltering]
        public ICollection<ContentStringMetaValue> ContentStringMetaValues { get; set; }
        [UseFiltering]
        public ICollection<ContentBoolMetaValue> ContentBoolMetaValues { get; set; }
        [UseFiltering]
        public ICollection<ContentTextMetaValue> ContentTextMetaValues { get; set; }
    }
}
