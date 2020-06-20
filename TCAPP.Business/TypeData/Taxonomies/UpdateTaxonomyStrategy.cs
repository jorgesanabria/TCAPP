using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;
using TCAPP.DTO.TypeData.Taxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.TypeData.Taxonomies
{
    public class UpdateTaxonomyStrategy : IAsyncUpdateStrategy<Taxonomy, UpdateTaxonomyInput>
    {
        private readonly TCAPPContext _context;
        public UpdateTaxonomyStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<Taxonomy> UpdateAsync(UpdateTaxonomyInput input)
        {
            var taxonomy = await _context.Taxonomies.FindAsync(input.Id);
            taxonomy.Title = input.Title ?? taxonomy.Title;
            taxonomy.Multiple = input.Multiple ?? taxonomy.Multiple;
            taxonomy.Enabled = input.Enabled ?? taxonomy.Enabled;
            taxonomy.Updated = DateTime.Now;
            await _context.SaveChangesAsync();
            return taxonomy;
        }
    }
}
