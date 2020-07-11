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
        public IQueryable<ContentType> GetContentTypes([Service] TCAPPContext context, int? skip, int? take)
        {
            var result = context.ContentTypes.AsQueryable();
            if (skip.HasValue)
            {
                result = result.Skip(skip.Value).AsQueryable();
            }
            if (take.HasValue)
            {
                result = result.Take(take.Value).AsQueryable();
            }

            return result;
        }
    }
}
