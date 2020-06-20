using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ParentContents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ParentContents
{
    public class DeleteParentContentStrategy : IAsyncDeleteStrategy<CreateOrDeleteParentInput>
    {
        private readonly TCAPPContext _context;
        public DeleteParentContentStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(CreateOrDeleteParentInput input)
        {
            var parentContent = new ParentContent { IdParentContent = input.IdParent, IdContent = input.IdContent };
            _context.Entry(parentContent).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
