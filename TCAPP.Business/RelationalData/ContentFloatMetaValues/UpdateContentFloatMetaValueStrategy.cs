using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentFloatMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentFloatMetaValues
{
    public class UpdateContentFloatMetaValueStrategy : IAsyncUpdateStrategy<ContentFloatMetaValue, UpdateFloatMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentFloatMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentFloatMetaValue> UpdateAsync(UpdateFloatMetaValueInput input)
        {
            var metaValue = await _context.ContentFloatMetaValues.FindAsync(input.IdContent, input.IdMetaValueType);
            metaValue.Updated = DateTime.Now;
            metaValue.Enabled = input.Enabled ?? metaValue.Enabled;
            metaValue.Value = input.Value ?? metaValue.Value;
            await _context.SaveChangesAsync();
            return metaValue;
        }
    }
}
