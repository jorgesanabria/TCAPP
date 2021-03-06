﻿using System;
using System.Collections.Generic;
using TCAPP.Domain.RelationalData;

namespace TCAPP.Domain.TypeData
{
    public class MetaValueType
    {
        public MetaValueType()
        {
            ContentFloatMetaValues = new HashSet<ContentFloatMetaValue>();
            ContentStringMetaValues = new HashSet<ContentStringMetaValue>();
            ContentBoolMetaValues = new HashSet<ContentBoolMetaValue>();
            ContentTextMetaValues = new HashSet<ContentTextMetaValue>();
        }
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
        public ICollection<ContentFloatMetaValue> ContentFloatMetaValues { get; set; }
        public ICollection<ContentStringMetaValue> ContentStringMetaValues { get; set; }
        public ICollection<ContentBoolMetaValue> ContentBoolMetaValues { get; set; }
        public ICollection<ContentTextMetaValue> ContentTextMetaValues { get; set; }
    }
}
