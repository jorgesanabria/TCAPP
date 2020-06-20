using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class CreateBoolMetaValueMutation
    {
        private readonly IAsyncCreateStrategy<ContentBoolMetaValue, CreateBoolMetaValueInput> _strategy;
        public CreateBoolMetaValueMutation(IAsyncCreateStrategy<ContentBoolMetaValue, CreateBoolMetaValueInput> strategy)
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
