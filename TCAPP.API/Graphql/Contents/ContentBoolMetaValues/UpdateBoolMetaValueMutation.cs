using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    public class UpdateBoolMetaValueMutation
    {
        private readonly IAsyncUpdateStrategy<ContentBoolMetaValue, UpdateBoolMetaValueInput> _strategy;
        public UpdateBoolMetaValueMutation(IAsyncUpdateStrategy<ContentBoolMetaValue, UpdateBoolMetaValueInput> strategy)
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
