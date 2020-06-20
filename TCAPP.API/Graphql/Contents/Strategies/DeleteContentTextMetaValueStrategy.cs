using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class DeleteContentTextMetaValueStrategy : IAsyncDelete<DeleteTextMetaValueInput>
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
