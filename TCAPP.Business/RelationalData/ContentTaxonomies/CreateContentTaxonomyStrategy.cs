using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentTaxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentTaxonomies
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
