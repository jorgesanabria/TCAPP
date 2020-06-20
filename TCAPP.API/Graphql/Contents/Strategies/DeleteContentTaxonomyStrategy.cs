using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.ContentTaxonomies;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class DeleteContentTaxonomyStrategy : IAsyncDelete<CreateOrDeleteContentTaxonomyInput>
    {
        private readonly TCAPPContext _context;
        public DeleteContentTaxonomyStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(CreateOrDeleteContentTaxonomyInput input)
        {
            var contentTaxonomy = new ContentTaxonomy { IdContent = input.IdContent, IdTaxonomy = input.IdTaxonomy };
            _context.Entry(contentTaxonomy).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
