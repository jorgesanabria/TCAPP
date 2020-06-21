using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.ContentTaxonomies
{
    [ExtendObjectType(Name = "Query")]
    public class ContentTaxonomyQuery
    {
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentTaxonomy> GetContentTaxonomy([Service] TCAPPContext context) => context.ContentTaxonomies;
    }
}
