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
        public IQueryable<Taxonomy> GetTaxonomies([Service] TCAPPContext context) => context.Taxonomies;
    }
}
