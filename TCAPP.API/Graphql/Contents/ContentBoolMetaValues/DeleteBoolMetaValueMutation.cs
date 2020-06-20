using System.Threading.Tasks;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    public class DeleteBoolMetaValueMutation
    {
        private readonly IAsyncDeleteStrategy<DeleteBoolMetaValueInput> _strategy;
        public DeleteBoolMetaValueMutation(IAsyncDeleteStrategy<DeleteBoolMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteBoolMetaValue(DeleteBoolMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
