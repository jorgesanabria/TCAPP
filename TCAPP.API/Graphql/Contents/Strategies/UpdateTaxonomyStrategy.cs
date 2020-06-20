using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Taxonomies;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.TypeData;

namespace TCAPP.API.Graphql.Contents.Strategies
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
