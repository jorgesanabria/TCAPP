using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.TypeData;
using TCAPP.DTO.TypeData.ContentTypes;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.ContentTypes
{
    [ExtendObjectType(Name = "Mutation")]
    public class ContentTypeMutation
    {
        public async Task<ContentType> CreateContentType(
            [Service] IAsyncCreateStrategy<ContentType, CreateContentTypeInput> strategy,
            CreateContentTypeInput input
        )
        {
            return await strategy.CreateAsync(input);
        }
    }
}
