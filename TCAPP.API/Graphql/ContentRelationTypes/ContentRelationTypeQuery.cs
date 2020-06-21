using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.ContentRelationTypes
{
    [ExtendObjectType(Name = "Query")]
    public class ContentRelationTypeQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentRelationType> GetContentRelationTypes([Service] TCAPPContext context) => context.ContentRelationTypes;
    }
}
