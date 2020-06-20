using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    public class UpdateMutation
    {
        private readonly IAsyncUpdate<ContentBoolMetaValue, UpdateBoolMetaValueInput> _strategy;
        public UpdateMutation(IAsyncUpdate<ContentBoolMetaValue, UpdateBoolMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentBoolMetaValue> UpdateBoolMetaValue(UpdateBoolMetaValueInput input)
        {
            var result = await _strategy.UpdateAsync(input);
            return result;
        }
    }
}
