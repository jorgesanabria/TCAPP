using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.TypeData;
using TCAPP.Infrastructure.Generics;
using TCAPP.TypeData.ContentMetaValueTypes;

namespace TCAPP.API.Graphql.MetaValueTypes
{
    [ExtendObjectType(Name = "Mutation")]
    public class MetaValueTypeMutation
    {
        public async Task<MetaValueType> CreateMetaValueType(
            [Service] IAsyncCreateStrategy<MetaValueType, CreateContentMetaValueTypeInput> strategy,
            CreateContentMetaValueTypeInput metaValueType
        )
        {
            var result = await strategy.CreateAsync(metaValueType);
            return result;
        }
        public async Task<MetaValueType> UpdateMetaValueType(
            [Service] IAsyncUpdateStrategy<MetaValueType, UpdateContentMetaValueTypeInput> strategy,
            UpdateContentMetaValueTypeInput metaValueType
        )
        {
            var resut = await strategy.UpdateAsync(metaValueType);
            return resut;
        }
    }
}
