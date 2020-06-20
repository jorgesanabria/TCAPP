using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class DeleteBoolMetaValueMutation
    {
        private readonly IAsyncDeleteStrategy<DeleteBoolMetaValueInput> _strategy;
        public DeleteBoolMetaValueMutation(IAsyncDeleteStrategy<DeleteBoolMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteBool(DeleteBoolMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
