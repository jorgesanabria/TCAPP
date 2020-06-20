using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class DeleteContentStringMetaValueStrategy : IAsyncDelete<DeleteStringMetaValueInput>
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
