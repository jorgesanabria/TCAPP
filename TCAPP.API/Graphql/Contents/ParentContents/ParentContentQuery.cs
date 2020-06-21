using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ParentContents
{
    [ExtendObjectType(Name = "Query")]
    public class ParentContentQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ParentContent> GetParentContents([Service] TCAPPContext context) => context.ParentContents;
    }
}
