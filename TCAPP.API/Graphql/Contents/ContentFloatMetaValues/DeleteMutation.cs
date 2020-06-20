using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;

namespace TCAPP.API.Graphql.Contents.ContentFloatMetaValues
{
    public class DeleteMutation
    {
        private readonly IAsyncDeleteStrategy<DeleteFloatMetaValueInput> _strategy;
        public DeleteMutation(IAsyncDeleteStrategy<DeleteFloatMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteContentFloatMetaValue(DeleteFloatMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
