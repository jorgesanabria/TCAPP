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
            CreateContentTypeInput contentType
        )
        {
            return await strategy.CreateAsync(contentType);
        }
        public async Task<ContentType> UpdateContentType(
            [Service] IAsyncUpdateStrategy<ContentType, UpdateContentTypeInput> strategy,
            UpdateContentTypeInput contentType
        )
        {
            return await strategy.UpdateAsync(contentType);
        }
    }
}
