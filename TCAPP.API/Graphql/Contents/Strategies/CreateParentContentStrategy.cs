using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.Parents;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateParentContentStrategy : IAsyncCreateStrategy<ParentContent, CreateOrDeleteParentInput>
    {
        private readonly TCAPPContext _context;
        public CreateParentContentStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ParentContent> CreateAsync(CreateOrDeleteParentInput input)
        {
            var parent = await _context.Contents.FindAsync(input.IdParent);
            var child = await _context.Contents.FindAsync(input.IdContent);
            var parentContent = new ParentContent { Content = child };
            parent.ChildrenContents.Add(parentContent);
            await _context.SaveChangesAsync();
            return parentContent;
        }
    }
}
