using System.Threading.Tasks;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public interface IAsyncUpdate<TResult, TInput> where TResult : class where TInput : class
    {
        Task<TResult> UpdateAsync(TInput input);
    }
}
