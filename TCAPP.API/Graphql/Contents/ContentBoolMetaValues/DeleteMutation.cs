using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    public class DeleteMutation
    {
        private readonly IAsyncDelete<DeleteBoolMetaValueInput> _strategy;
        public DeleteMutation(IAsyncDelete<DeleteBoolMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteBoolMetaValue(DeleteBoolMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
