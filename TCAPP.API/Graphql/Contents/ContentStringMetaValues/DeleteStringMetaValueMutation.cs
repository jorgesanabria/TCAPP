using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.DTO.RelationalData.ContentStringMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentStringMetaValues
{
    [ExtendObjectType(Name = "Mutation")]
    public class DeleteStringMetaValueMutation
    {
        private readonly IAsyncDeleteStrategy<DeleteStringMetaValueInput> _strategy;
        public DeleteStringMetaValueMutation(IAsyncDeleteStrategy<DeleteStringMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task DeleteString(DeleteStringMetaValueInput input)
        {
            await _strategy.DeleteAsync(input);
        }
    }
}
