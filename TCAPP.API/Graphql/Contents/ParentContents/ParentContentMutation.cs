using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ParentContents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ParentContents
{
    [ExtendObjectType(Name = "Mutation")]
    public class ParentContentMutation
    {
        public async Task<ParentContent> CreateParentContent(
            [Service] IAsyncCreateStrategy<ParentContent, CreateOrDeleteParentInput> straategy,
            CreateOrDeleteParentInput parentContent
        ) => await straategy.CreateAsync(parentContent);
        public async Task<bool> DeleteParentContent(
            [Service] IAsyncDeleteStrategy<CreateOrDeleteParentInput> strategy,
            CreateOrDeleteParentInput parentContent
        )
        {
            await strategy.DeleteAsync(parentContent);
            return true;
        }
    }
}
