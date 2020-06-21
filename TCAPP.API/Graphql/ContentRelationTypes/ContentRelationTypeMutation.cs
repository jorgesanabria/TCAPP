using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.TypeData;
using TCAPP.Infrastructure.Generics;
using TCAPP.TypeData.ContentRelationTypes;

namespace TCAPP.API.Graphql.ContentRelationTypes
{
    [ExtendObjectType(Name = "Mutation")]
    public class ContentRelationTypeMutation
    {
        public async Task<ContentRelationType> CreateContentRelationType(
            [Service] IAsyncCreateStrategy<ContentRelationType, CreateContentRelationTypeInput> strategy,
            CreateContentRelationTypeInput contentRelationType
        ) => await strategy.CreateAsync(contentRelationType);
        public async Task<ContentRelationType> UpdateContentRelationType(
            [Service] IAsyncUpdateStrategy<ContentRelationType, UpdateContentRelationTypeInput> strategy,
            UpdateContentRelationTypeInput contentRelationType
        ) => await strategy.UpdateAsync(contentRelationType);
    }
}
