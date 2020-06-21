using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.ConcreteData;
using TCAPP.DTO.ConcreteData.Users;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Users
{
    [ExtendObjectType(Name = "Mutation")]
    public class UserMutation
    {
        public async Task<User> CreateUser(
            [Service] IAsyncCreateStrategy<User, CreateUserInput> strategy,
            CreateUserInput inputUser
        )
        {
            var result = await strategy.CreateAsync(inputUser);
            return result;
        }
    }
}
