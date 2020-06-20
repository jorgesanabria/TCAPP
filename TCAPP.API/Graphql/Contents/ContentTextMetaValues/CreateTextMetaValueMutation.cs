using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentTextMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentTextMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class CreateTextMetaValueMutation
    {
        private readonly IAsyncCreateStrategy<ContentTextMetaValue, CreateTextMetaValueInput> _strategy;
        public CreateTextMetaValueMutation(IAsyncCreateStrategy<ContentTextMetaValue, CreateTextMetaValueInput> strategy)
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
