using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents
{
    public class Mutation
    {
        private readonly IAsyncCreateStrategy<Content, CreateContentInput> _strategy;
        public Mutation(IAsyncCreateStrategy<Content, CreateContentInput> strategy)
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
