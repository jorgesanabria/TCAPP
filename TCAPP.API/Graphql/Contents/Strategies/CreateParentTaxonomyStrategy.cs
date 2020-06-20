using System.Threading.Tasks;
using TCAPP.API.Graphql.Taxonomies;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateParentTaxonomyStrategy : IAsyncCreateStrategy<ParentTaxonomy, CreaateOrDeleteParentTaxonomyInput>
    {
        private readonly TCAPPContext _context;
        public CreateParentTaxonomyStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ParentTaxonomy> CreateAsync(CreaateOrDeleteParentTaxonomyInput input)
        {
            var parent = await _context.Taxonomies.FindAsync(input.IdParent);
            var child = await _context.Taxonomies.FindAsync(input.IdTaxonomy);
            var parentTaxonomy = new ParentTaxonomy { Parent = parent, Taxonomy = child };
            parent.ParentTaxonomies.Add(parentTaxonomy);
            await _context.SaveChangesAsync();
            return parentTaxonomy;
        }
    }
}
