using HotChocolate;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.ObjectTypes
{
    public class UserContentResolver
    {
        public IQueryable<UserContent> GetUserContents(User user, [Service] TCAPPContext context)
            => context.UserContents.Where(x => x.IdUser == user.Id);
    }
}
