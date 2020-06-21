using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.ConcreteData;
using TCAPP.DTO.ConcreteData.Contents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents
{
    [ExtendObjectType(Name = "Mutation")]
    public class ContentMutation
    {
        public async Task<Content> CreateContent(
            [Service] IAsyncCreateStrategy<Content, CreateContentInput> strategy,
            CreateContentInput inputContent
        )
        {
            var result = await strategy.CreateAsync(inputContent);
            return result;
        }
    }
}
