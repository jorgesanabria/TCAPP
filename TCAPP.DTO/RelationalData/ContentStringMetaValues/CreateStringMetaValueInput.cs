﻿using System;

namespace TCAPP.DTO.RelationalData.ContentStringMetaValues
{
    public class CreateStringMetaValueInput
    {
        public Guid IdContent { get; set; }
        public long IdMetaValueType { get; set; }
        public string Value { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Enabled { get; set; }
    }
}
