using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class UpdateContentTextMetaValueStrategy : IAsyncUpdate<ContentTextMetaValue, UpdateTextMetaValueInput>
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
