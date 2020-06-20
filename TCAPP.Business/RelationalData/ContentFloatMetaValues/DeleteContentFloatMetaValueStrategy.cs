using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.DTO.RelationalData.ContentFloatMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentFloatMetaValues
{
    public class DeleteContentFloatMetaValueStrategy : IAsyncDeleteStrategy<DeleteFloatMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public DeleteContentFloatMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(DeleteFloatMetaValueInput input)
        {
            var metaValue = await _context.ContentFloatMetaValues.FindAsync(input.IdContent, input.IdMetaValueType);
            _context.ContentFloatMetaValues.Remove(metaValue);
            await _context.SaveChangesAsync();
        }
    }
}
