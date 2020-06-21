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
            CreateContentInput content
        )
        {
            var result = await strategy.CreateAsync(content);
            return result;
        }
        public async Task<Content> UpdateContent(
            [Service] IAsyncUpdateStrategy<Content, UpdateContentInput> strategy,
            UpdateContentInput content
        )
        {
            var result = await strategy.UpdateAsync(content);
            return result;
        }
    }
}
