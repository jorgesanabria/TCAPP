using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class DeleteContentFloatMetaValueStrategy : IAsyncDelete<DeleteFloatMetaValueInput>
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
