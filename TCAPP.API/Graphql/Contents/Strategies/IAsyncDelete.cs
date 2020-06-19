using System.Threading.Tasks;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public interface IAsyncDelete<TInput> where TInput : class
    {
        Task DeleteAsync(TInput input);
    }
}
