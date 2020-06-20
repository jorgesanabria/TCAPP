using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Users;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class CreateUserStrategy : IAsyncCreateStrategy<User, CreateUserInput>
    {
        private readonly TCAPPContext _context;
        public CreateUserStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(CreateUserInput input)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                Email = input.Email,
                Password = input.Password,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Enabled = input.Enabled
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            user.Password = null;
            return user;
        }
    }
}
