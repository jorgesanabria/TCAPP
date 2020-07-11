using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentBoolMetaValues
{
    [ExtendObjectType(Name = "Query")]
    public class ContentBoolMetaValueQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentBoolMetaValue> GetContentBoolMetaValue([Service] TCAPPContext context, int? skip, int? take)
        {
            var result = context.ContentBoolMetaValues.AsQueryable();
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
