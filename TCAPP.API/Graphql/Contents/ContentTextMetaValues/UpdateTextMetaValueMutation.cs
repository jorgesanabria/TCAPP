using System.Threading.Tasks;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentTextMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.API.Graphql.Contents.ContentTextMetaValues
{
    public class UpdateTextMetaValueMutation
    {
        private readonly IAsyncUpdateStrategy<ContentTextMetaValue, UpdateTextMetaValueInput> _strategy;
        public UpdateTextMetaValueMutation(IAsyncUpdateStrategy<ContentTextMetaValue, UpdateTextMetaValueInput> strategy)
        {
            _strategy = strategy;
        }
        public async Task<ContentTextMetaValue> UpdateContentTextMetaValue(UpdateTextMetaValueInput input)
        {
            return await _strategy.UpdateAsync(input);
        }
    }
}
