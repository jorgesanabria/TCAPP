using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentStringMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentStringMetaValues
{
    public class UpdateStringMetaValueMutation
    {
        private readonly IAsyncUpdateStrategy<ContentStringMetaValue, UpdateStringMetaValueInput> _strategy;
        public UpdateStringMetaValueMutation(IAsyncUpdateStrategy<ContentStringMetaValue, UpdateStringMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentStringMetaValue> UpdateContentStringMetaValue(UpdateStringMetaValueInput input)
        {
            return await _strategy.UpdateAsync(input);
        }
    }
}
