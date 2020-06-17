using System.Threading.Tasks;
using TCAPP.Domain.ConcreteData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public interface ICreateContentStrategy
    {
        Task<Content> CreateAsync(CreateContentInput input);
    }
}
