using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Users;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class UpdateUserStrategy : IAsyncUpdate<User, UpdateUserInput>
    {
        private TCAPPContext _context;
        public UpdateUserStrategy (TCAPPContext context)
        {
            _context = context;
        }
        public async Task<User> UpdateAsync(UpdateUserInput input)
        {
            var user = await _context.Users.FindAsync(input.Id);
            user.Name = input.Name ?? user.Name;
            user.Email = input.Email ?? user.Email;
            user.Password = input.Password ?? user.Password;
            user.Updated = DateTime.Now;
            await _context.SaveChangesAsync();
            user.Password = null;
            return user;
        }
    }
}
