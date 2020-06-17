using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents
{
    public class Mutation
    {
        private readonly ICreateContentStrategy _strategy;
        public Mutation(ICreateContentStrategy strategy)
        {
            _strategy = strategy;
        }
        public async Task<Content> CreateContent(CreateContentInput inputContent)
        {
            return await _strategy.CreateAsync(inputContent);
        }
    }
}
