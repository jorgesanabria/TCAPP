using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.Taxonomies
{
    [ExtendObjectType(Name = "Query")]
    public class TaxonomyQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Taxonomy> GetTaxonomies([Service] TCAPPContext context, int? skip, int? take)
        {
            var result = context.Taxonomies.AsQueryable();
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
