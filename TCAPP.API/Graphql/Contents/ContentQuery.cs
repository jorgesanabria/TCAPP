using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents
{
    [ExtendObjectType(Name = "Query")]
    public class ContentQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Content> GetContents([Service] TCAPPContext context) => context.Contents;

        //[UsePaging]
        //[UseSelection]
        //[UseFiltering]
        //[UseSorting]
        //public IQueryable<UserData> GetUsers([Service] TCAPPContext context) =>
        //    context.Users.Select(x => new UserData
        //    {
        //        Id = x.Id,
        //        Email = x.Email,
        //        Name = x.Name,
        //        Created = x.Created,
        //        Updated = x.Updated,
        //        Enabled = x.Enabled,
        //        UserContents = x.UserContents
        //    });
    }
}
