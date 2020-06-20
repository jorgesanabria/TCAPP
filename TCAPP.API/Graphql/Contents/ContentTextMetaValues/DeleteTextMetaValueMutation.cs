using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.DTO.RelationalData.ContentTextMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentTextMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class DeleteTextMetaValueMutation
    {
        private readonly IAsyncDeleteStrategy<DeleteTextMetaValueInput> _strategy;
        public DeleteTextMetaValueMutation(IAsyncDeleteStrategy<DeleteTextMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteText(DeleteTextMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
