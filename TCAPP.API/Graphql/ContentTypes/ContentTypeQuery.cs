using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.ContentTypes
{
    [ExtendObjectType(Name = "Query")]
    public class ContentTypeQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentType> GetContentTypes([Service] TCAPPContext context) => context.ContentTypes;
    }
}
