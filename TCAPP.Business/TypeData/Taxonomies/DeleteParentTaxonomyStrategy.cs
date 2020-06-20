using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.TypeData.Taxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.TypeData.Taxonomies
{
    public class DeleteParentTaxonomyStrategy : IAsyncDeleteStrategy<CreateOrDeleteParentTaxonomyInput>
    {
        private TCAPPContext _context;
        public DeleteParentTaxonomyStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(CreateOrDeleteParentTaxonomyInput input)
        {
            var parentTaxonomy = new ParentTaxonomy { IdParentTaxonomy = input.IdParent, IdTaxonomy = input.IdTaxonomy };
            _context.Entry(parentTaxonomy).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
