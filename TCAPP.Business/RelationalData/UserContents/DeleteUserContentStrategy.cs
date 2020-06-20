using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.UserContents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.UserContents
{
    public class DeleteUserContentStrategy : IAsyncDeleteStrategy<CreateOrDeleteUserContentInput>
    {
        private readonly TCAPPContext _context;
        public DeleteUserContentStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(CreateOrDeleteUserContentInput input)
        {
            var userContent = new UserContent
            {
                IdContent = input.IdContent,
                IdContentRelationType = input.IdContentRelationType,
                IdUser = input.IdUser
            };
            _context.Entry(userContent).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
