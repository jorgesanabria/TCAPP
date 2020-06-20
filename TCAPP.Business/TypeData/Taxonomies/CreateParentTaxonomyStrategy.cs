using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.TypeData.Taxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.TypeData.Taxonomies
{
    public class CreateParentTaxonomyStrategy : IAsyncCreateStrategy<ParentTaxonomy, CreateOrDeleteParentTaxonomyInput>
    {
        private readonly TCAPPContext _context;
        public CreateParentTaxonomyStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ParentTaxonomy> CreateAsync(CreateOrDeleteParentTaxonomyInput input)
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
