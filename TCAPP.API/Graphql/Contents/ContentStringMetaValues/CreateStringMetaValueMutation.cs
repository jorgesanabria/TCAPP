using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentStringMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentStringMetaValues
{
    public class CreateStringMetaValueMutation
    {
        private readonly IAsyncCreateStrategy<ContentStringMetaValue, CreateStringMetaValueInput> _strategy;
        public CreateStringMetaValueMutation(IAsyncCreateStrategy<ContentStringMetaValue, CreateStringMetaValueInput> strategy)
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
