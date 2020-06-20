using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ParentContents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ParentContents
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
