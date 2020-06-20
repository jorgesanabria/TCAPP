using HotChocolate.Types;
using System.Threading.Tasks;
using TCAPP.Domain.ConcreteData;
using TCAPP.DTO.ConcreteData.Contents;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents
{
    [ExtendObjectType(Name = "Mutation")]
    public class CreateContentMutation
    {
        private readonly IAsyncCreateStrategy<Content, CreateContentInput> _strategy;
        public CreateContentMutation(IAsyncCreateStrategy<Content, CreateContentInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<Content> CreateContent(CreateContentInput inputContent)
        {
            var result = await _strategy.CreateAsync(inputContent);
            return result;
        }
    }
}
