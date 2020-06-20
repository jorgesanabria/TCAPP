using System.Threading.Tasks;

namespace TCAPP.Infrastructure.Generics
{
    public interface IAsyncUpdateStrategy<TResult, TInput> where TResult : class where TInput : class
    {
        Task<TResult> UpdateAsync(TInput input);
    }
}
