using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;

namespace TCAPP.API.Graphql.Contents.ContentTextMetaValues
{
    public class DeleteMutation
    {
        private readonly IAsyncDeleteStrategy<DeleteTextMetaValueInput> _strategy;
        public DeleteMutation(IAsyncDeleteStrategy<DeleteTextMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteContentTextMetaValue(DeleteTextMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
