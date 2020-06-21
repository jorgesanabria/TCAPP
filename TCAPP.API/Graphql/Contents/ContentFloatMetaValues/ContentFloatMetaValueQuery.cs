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
        public IQueryable<ContentFloatMetaValue> GetContentFloatMetaValue([Service] TCAPPContext context) => context.ContentFloatMetaValues;
    }
}
