using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.DTO.RelationalData.ContentTextMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentTextMetaValues
{
    public class DeleteContentTextMetaValueStrategy : IAsyncDeleteStrategy<DeleteTextMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public DeleteContentTextMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(DeleteTextMetaValueInput input)
        {
            var metaValue = await _context.ContentTextMetaValues.FindAsync(input.IdContent, input.IdMetaValueType);
            _context.ContentTextMetaValues.Remove(metaValue);
            await _context.SaveChangesAsync();
        }
    }
}
