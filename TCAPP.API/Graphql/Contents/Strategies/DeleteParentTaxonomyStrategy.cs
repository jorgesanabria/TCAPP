using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Taxonomies;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class DeleteParentTaxonomyStrategy : IAsyncDelete<CreaateOrDeleteParentTaxonomyInput>
    {
        private TCAPPContext _context;
        public DeleteParentTaxonomyStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(CreaateOrDeleteParentTaxonomyInput input)
        {
            var parentTaxonomy = new ParentTaxonomy { IdParentTaxonomy = input.IdParent, IdTaxonomy = input.IdTaxonomy };
            _context.Entry(parentTaxonomy).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
