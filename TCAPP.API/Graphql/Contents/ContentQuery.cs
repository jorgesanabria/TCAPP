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
        public IQueryable<Content> GetContents([Service] TCAPPContext context, int? skip, int? take)
        {
            var result = context.Contents.AsQueryable();
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
