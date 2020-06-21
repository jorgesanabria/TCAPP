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
        public IQueryable<ParentTaxonomy> GetParentTaxonomies([Service] TCAPPContext context) => context.ParentTaxonomies;
    }
}
