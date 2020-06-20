using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class UpdateBoolMetaValueMutation
    {
        private readonly IAsyncUpdateStrategy<ContentBoolMetaValue, UpdateBoolMetaValueInput> _strategy;
        public UpdateBoolMetaValueMutation(IAsyncUpdateStrategy<ContentBoolMetaValue, UpdateBoolMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentBoolMetaValue> UpdateBool(UpdateBoolMetaValueInput input)
        {
            var result = await _strategy.UpdateAsync(input);
            return result;
        }
    }
}
