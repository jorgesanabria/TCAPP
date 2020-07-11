using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Users
{
    [ExtendObjectType(Name = "Query")]
    public class UserQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] TCAPPContext context, int? skip, int? take)
        {
            var result = context.Users.AsQueryable();
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
