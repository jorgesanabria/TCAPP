using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.Parents;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class DeleteParentContentStrategy : IAsyncDelete<CreateOrDeleteParentInput>
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
