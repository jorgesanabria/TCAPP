using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.UserContents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Users.UserContents
{
    [ExtendObjectType(Name = "Mutation")]
    public class UserContentMutation
    {
        public async Task<UserContent> CreateUserContent(
            [Service] IAsyncCreateStrategy<UserContent, CreateOrDeleteUserContentInput> strategy,
            CreateOrDeleteUserContentInput userContent
        ) => await strategy.CreateAsync(userContent);
        public async Task<bool> DeleteUserContent(
            [Service] IAsyncDeleteStrategy<CreateOrDeleteUserContentInput> strategy,
            CreateOrDeleteUserContentInput userContent
        )
        {
            await strategy.DeleteAsync(userContent);
            return true;
        }
    }
}
