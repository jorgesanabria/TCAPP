using System;
using System.Threading.Tasks;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;
using TCAPP.DTO.RelationalData.ContentTextMetaValues;
using TCAPP.Infrastructure.Generics;

namespace TCAPP.Business.RelationalData.ContentTextMetaValues
{
    public class UpdateContentTextMetaValueStrategy : IAsyncUpdateStrategy<ContentTextMetaValue, UpdateTextMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentTextMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentTextMetaValue> UpdateAsync(UpdateTextMetaValueInput input)
        {
            var metaValue = await _context.ContentTextMetaValues.FindAsync(input.IdContent, input.IdMetaValueType);
            metaValue.Updated = DateTime.Now;
            metaValue.Enabled = input.Enabled ?? metaValue.Enabled;
            metaValue.Value = input.Value ?? metaValue.Value;
            await _context.SaveChangesAsync();
            return metaValue;
        }
    }
}
