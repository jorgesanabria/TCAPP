﻿using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentStringMetaValues
{
    public class UpdateMutation
    {
        private readonly IAsyncUpdateStrategy<ContentStringMetaValue, UpdateStringMetaValueInput> _strategy;
        public UpdateMutation(IAsyncUpdateStrategy<ContentStringMetaValue, UpdateStringMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentStringMetaValue> UpdateContentStringMetaValue(UpdateStringMetaValueInput input)
        {
            return await _strategy.UpdateAsync(input);
        }
    }
}
