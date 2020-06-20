using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentFloatMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentFloatMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class UpdateFloatMetaValueMutation
    {
        private readonly IAsyncUpdateStrategy<ContentFloatMetaValue, UpdateFloatMetaValueInput> _strategy;
        public UpdateFloatMetaValueMutation(IAsyncUpdateStrategy<ContentFloatMetaValue, UpdateFloatMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentFloatMetaValue> UpdateFloat(UpdateFloatMetaValueInput input)
        {
            var resut = await _strategy.UpdateAsync(input);
            return resut;
        }
    }
}
