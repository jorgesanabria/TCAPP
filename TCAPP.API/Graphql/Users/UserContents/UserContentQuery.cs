using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Users.UserContents
{
    [ExtendObjectType(Name = "Query")]
    public class UserContentQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UserContent> GetUserContents([Service] TCAPPContext context) => context.UserContents;
    }
}
