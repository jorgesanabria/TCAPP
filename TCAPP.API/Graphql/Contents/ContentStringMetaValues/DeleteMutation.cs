using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;

namespace TCAPP.API.Graphql.Contents.ContentStringMetaValues
{
    public class DeleteMutation
    {
        private readonly IAsyncDeleteStrategy<DeleteStringMetaValueInput> _strategy;
        public DeleteMutation(IAsyncDeleteStrategy<DeleteStringMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteContentStringMetaValue(DeleteStringMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
