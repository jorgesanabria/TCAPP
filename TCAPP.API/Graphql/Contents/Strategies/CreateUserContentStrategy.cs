using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.UserContents;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateUserContentStrategy : IAsyncCreateStrategy<UserContent, CreateOrDeleteUserContentInput>
    {
        private readonly TCAPPContext _context;
        public CreateUserContentStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<UserContent> CreateAsync(CreateOrDeleteUserContentInput input)
        {
            var userContent = new UserContent
            {
                IdContent = input.IdContent,
                IdUser = input.IdUser,
                IdContentRelationType = input.IdContentRelationType
            };
            _context.UserContents.Add(userContent);
            await _context.SaveChangesAsync();
            return await _context.UserContents.FirstAsync(x => x.IdContent == input.IdContent && x.IdUser == input.IdUser && x.IdContentRelationType == input.IdContentRelationType);
        }
    }
}
