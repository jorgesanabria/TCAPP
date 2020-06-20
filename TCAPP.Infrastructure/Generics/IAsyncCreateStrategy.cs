using System.Threading.Tasks;

namespace TCAPP.Infrastructure.Generics
{
    public interface IAsyncCreateStrategy<TReturn, TInput> where TReturn : class where TInput : class
    {
        Task<TReturn> CreateAsync(TInput input);
    }
}
