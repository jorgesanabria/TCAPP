using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentBoolMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentBoolMetaValues
{
    public class UpdateContentBoolMetaValueStrategy : IAsyncUpdateStrategy<ContentBoolMetaValue, UpdateBoolMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentBoolMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentBoolMetaValue> UpdateAsync(UpdateBoolMetaValueInput input)
        {
            var metaValue = await _context.ContentBoolMetaValues.FindAsync(input.IdContent, input.IdMetaValueType);
            metaValue.Updated = DateTime.Now;
            metaValue.Enabled = input.Enabled ?? metaValue.Enabled;
            metaValue.Value = input.Value ?? metaValue.Value;
            await _context.SaveChangesAsync();
            return metaValue;
        }
    }
}
