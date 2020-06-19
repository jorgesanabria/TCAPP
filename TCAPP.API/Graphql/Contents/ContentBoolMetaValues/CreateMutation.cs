using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    public class CreateMutation
    {
        private readonly IAsyncCreateStrategy<ContentBoolMetaValue, CreateBoolMetaValueInput> _strategy;
        public CreateMutation(IAsyncCreateStrategy<ContentBoolMetaValue, CreateBoolMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentBoolMetaValue> CreateBool(CreateBoolMetaValueInput inputContent)
        {
            var result = await _strategy.CreateAsync(inputContent);
            return result;
        }
    }
}
