using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Users
{
    public class UserQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] TCAPPContext context) => context.Users;
    }
}
