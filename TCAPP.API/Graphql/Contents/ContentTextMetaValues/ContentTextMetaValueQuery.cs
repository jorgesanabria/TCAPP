using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentTextMetaValues
{
    [ExtendObjectType(Name = "Query")]
    public class ContentTextMetaValueQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentTextMetaValue> GetContentTextMetaValue([Service] TCAPPContext context) => context.ContentTextMetaValues;
    }
}
