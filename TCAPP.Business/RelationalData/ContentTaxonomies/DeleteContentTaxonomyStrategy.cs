using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentTaxonomies;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentTaxonomies
{
    public class DeleteContentTaxonomyStrategy : IAsyncDeleteStrategy<CreateOrDeleteContentTaxonomyInput>
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
