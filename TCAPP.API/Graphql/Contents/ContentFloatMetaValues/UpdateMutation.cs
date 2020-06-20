﻿using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentFloatMetaValues
{
    public class UpdateMutation
    {
        private readonly IAsyncUpdate<ContentFloatMetaValue, UpdateFloatMetaValueInput> _strategy;
        public UpdateMutation(IAsyncUpdate<ContentFloatMetaValue, UpdateFloatMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentFloatMetaValue> UpdateContentFloatMetaValue(UpdateFloatMetaValueInput input)
        {
            var resut = await _strategy.UpdateAsync(input);
            return resut;
        }
    }
}
