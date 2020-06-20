using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentFloatMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentFloatMetaValues
{
    public class CreateContentFloatMetaVaueStrategy : IAsyncCreateStrategy<ContentFloatMetaValue, CreateFloatMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public CreateContentFloatMetaVaueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentFloatMetaValue> CreateAsync(CreateFloatMetaValueInput input)
        {
            var metaValue = new ContentFloatMetaValue
            {
                IdContent = input.IdContent,
                IdMetaValueType = input.IdMetaValueType,
                Created = input.Created,
                Updated = input.Updated,
                Enabled = input.Enabled,
                Value = input.Value
            };
            _context.ContentFloatMetaValues.Add(metaValue);
            await _context.SaveChangesAsync();
            return await _context.ContentFloatMetaValues.FindAsync(metaValue.IdContent, metaValue.IdMetaValueType);
        }
    }
}
