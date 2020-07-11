using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentFloatMetaValues
{
    [ExtendObjectType(Name = "Query")]
    public class ContentFloatMetaValueQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentFloatMetaValue> GetContentFloatMetaValue([Service] TCAPPContext context, int? skip, int? take)
        {
            var result = context.ContentFloatMetaValues.AsQueryable();
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
