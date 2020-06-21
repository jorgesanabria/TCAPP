using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.MetaValueTypes
{
    [ExtendObjectType(Name = "Query")]
    public class MetaValueTypeQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<MetaValueType> GetMetaValueTypes([Service] TCAPPContext context) => context.MetaValueTypes;
    }
}
