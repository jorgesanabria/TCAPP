using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Taxonomies.ParentTaxonomies
{
    [ExtendObjectType(Name = "Query")]
    public class ParentTaxonomyQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ParentTaxonomy> GetParentTaxonomies([Service] TCAPPContext context, int? skip, int? take)
        {
            var result = context.ParentTaxonomies.AsQueryable();
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
