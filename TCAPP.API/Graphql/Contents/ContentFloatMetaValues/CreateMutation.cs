using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentFloatMetaValues
{
    public class CreateMutation
    {
        private readonly IAsyncCreateStrategy<ContentFloatMetaValue, CreateFloatMetaValueInput> _strategy;
        public CreateMutation(IAsyncCreateStrategy<ContentFloatMetaValue, CreateFloatMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentFloatMetaValue> CreateFloat(CreateFloatMetaValueInput inputContent)
        {
            var result = await _strategy.CreateAsync(inputContent);
            return result;
        }
    }
}
