using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;
using TCAPP.DTO.ConcreteData.Users;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.ConcreteData.Users
{
    public class UpdateUserStrategy : IAsyncUpdateStrategy<User, UpdateUserInput>
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
