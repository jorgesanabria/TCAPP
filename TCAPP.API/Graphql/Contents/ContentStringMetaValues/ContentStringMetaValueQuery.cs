using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentStringMetaValues
{
    [ExtendObjectType(Name = "Query")]
    public class ContentStringMetaValueQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentStringMetaValue> GetContentStringMetaValue([Service] TCAPPContext context) => context.ContentStringMetaValues;
    }
}
