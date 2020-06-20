using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.ContentTaxonomies;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateContentTaxonomyStrategy : IAsyncCreateStrategy<ContentTaxonomy, CreateOrDeleteContentTaxonomyInput>
    {
        private TCAPPContext _context;
        public CreateContentTaxonomyStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentTaxonomy> CreateAsync(CreateOrDeleteContentTaxonomyInput input)
        {
            var content = await _context.Contents.FindAsync(input.IdContent);
            var taxonomy = await _context.Taxonomies.FindAsync(input.IdTaxonomy);
            var contentTaxonomy = new ContentTaxonomy { Content = content, Taxonomy = taxonomy };
            content.ContentTaxonomies.Add(contentTaxonomy);
            await _context.SaveChangesAsync();
            return contentTaxonomy;
        }
    }
}
