using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;

namespace TCAPP.API.Graphql.Contents.ContentStringMetaValues
{
    public class DeleteMutation
    {
        private readonly IAsyncDelete<DeleteStringMetaValueInput> _strategy;
        public DeleteMutation(IAsyncDelete<DeleteStringMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteContentStringMetaValue(DeleteStringMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
