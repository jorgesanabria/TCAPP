using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class DeleteContentBoolMetaValueStrategy : IAsyncDelete<DeleteBoolMetaValueInput>
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
