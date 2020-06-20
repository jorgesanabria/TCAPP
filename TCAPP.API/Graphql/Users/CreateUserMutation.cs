using System.Threading.Tasks;
using TCAPP.Domain.ConcreteData;
using TCAPP.DTO.ConcreteData.Users;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Users
{
    public class CreateUserMutation
    {
        private readonly IAsyncCreateStrategy<User, CreateUserInput> _strategy;
        public CreateUserMutation(IAsyncCreateStrategy<User, CreateUserInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<User> CreateContent(CreateUserInput inputContent)
        {
            var result = await _strategy.CreateAsync(inputContent);
            return result;
        }
    }
}
