using System.Threading.Tasks;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public interface IAsyncDeleteStrategy<TInput> where TInput : class
    {
        Task DeleteAsync(TInput input);
    }
}
