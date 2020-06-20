using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentTextMetaValues
{
    public class UpdateMutation
    {
        private readonly IAsyncUpdate<ContentTextMetaValue, UpdateTextMetaValueInput> _strategy;
        public UpdateMutation(IAsyncUpdate<ContentTextMetaValue, UpdateTextMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentTextMetaValue> UpdateContentTextMetaValue(UpdateTextMetaValueInput input)
        {
            return await _strategy.UpdateAsync(input);
        }
    }
}
