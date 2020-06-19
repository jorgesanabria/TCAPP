using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentTextMetaValues
{
    public class CreateMutation
    {
        private readonly IAsyncCreateStrategy<ContentTextMetaValue, CreateTextMetaValueInput> _strategy;
        public CreateMutation(IAsyncCreateStrategy<ContentTextMetaValue, CreateTextMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentTextMetaValue> CreateText(CreateTextMetaValueInput inputContent)
        {
            var result = await _strategy.CreateAsync(inputContent);
            return result;
        }
    }
}
