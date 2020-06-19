using System.Threading.Tasks;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public interface IAsyncCreateStrategy<TReturn, TInput> where TReturn : class where TInput : class
    {
        Task<TReturn> CreateAsync(TInput input);
    }
}
