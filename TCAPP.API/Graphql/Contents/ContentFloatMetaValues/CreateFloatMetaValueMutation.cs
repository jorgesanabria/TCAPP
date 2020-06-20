using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentFloatMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentFloatMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class CreateFloatMetaValueMutation
    {
        private readonly IAsyncCreateStrategy<ContentFloatMetaValue, CreateFloatMetaValueInput> _strategy;
        public CreateFloatMetaValueMutation(IAsyncCreateStrategy<ContentFloatMetaValue, CreateFloatMetaValueInput> strategy)
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
