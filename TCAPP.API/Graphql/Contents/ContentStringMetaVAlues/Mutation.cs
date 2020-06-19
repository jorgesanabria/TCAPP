using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentStringMetaValues
{
    public class Mutation
    {
        private readonly IAsyncCreateStrategy<ContentStringMetaValue, CreateStringMetaValueInput> _strategy;
        public Mutation(IAsyncCreateStrategy<ContentStringMetaValue, CreateStringMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentStringMetaValue> CreateString(CreateStringMetaValueInput inputContent)
        {
            var result = await _strategy.CreateAsync(inputContent);
            return result;
        }
    }
}
