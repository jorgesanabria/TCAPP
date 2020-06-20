using System.Threading.Tasks;

namespace TCAPP.Infrastructure.Generics
{
    public interface IAsyncDeleteStrategy<TInput> where TInput : class
    {
        Task DeleteAsync(TInput input);
    }
}
