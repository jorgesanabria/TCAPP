using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentBoolMetaValues
{
    public class DeleteContentBoolMetaValueStrategy : IAsyncDeleteStrategy<DeleteBoolMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public DeleteContentBoolMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(DeleteBoolMetaValueInput input)
        {
            var metaValue = await _context.ContentBoolMetaValues.FindAsync(input.IdContent, input.IdMetaValueType);
            _context.ContentBoolMetaValues.Remove(metaValue);
            await _context.SaveChangesAsync();
        }
    }
}
