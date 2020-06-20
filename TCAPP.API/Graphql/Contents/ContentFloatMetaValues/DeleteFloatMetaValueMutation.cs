using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.DTO.RelationalData.ContentFloatMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentFloatMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class DeleteFloatMetaValueMutation
    {
        private readonly IAsyncDeleteStrategy<DeleteFloatMetaValueInput> _strategy;
        public DeleteFloatMetaValueMutation(IAsyncDeleteStrategy<DeleteFloatMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteFloat(DeleteFloatMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
