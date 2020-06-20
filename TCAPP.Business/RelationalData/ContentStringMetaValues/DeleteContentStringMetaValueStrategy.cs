using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.DTO.RelationalData.ContentStringMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentStringMetaValues
{
    public class DeleteContentStringMetaValueStrategy : IAsyncDeleteStrategy<DeleteStringMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public DeleteContentStringMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(DeleteStringMetaValueInput input)
        {
            var metaValue = await _context.ContentStringMetaValues.FindAsync(input.IdContent, input.IdMetaValueType);
            _context.ContentStringMetaValues.Remove(metaValue);
            await _context.SaveChangesAsync();
        }
    }
}
