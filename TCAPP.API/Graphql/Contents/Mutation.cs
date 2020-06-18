using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.Strategies;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents
{
    public class Mutation
    {
        private readonly ICreateContentStrategy _strategy;
        private readonly TCAPPContext _context;
        public Mutation(ICreateContentStrategy strategy, TCAPPContext context)
        {
            _strategy = strategy;
            _context = context;
        }
        public async Task<Content> CreateContent(CreateContentInput inputContent)
        {
            var result = await _strategy.CreateAsync(inputContent);
            return result;
        }
    }
}
