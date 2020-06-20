using System;
using System.Threading.Tasks;
using TCAPP.API.Graphql.Contents.MetaValues;
using TCAPP.DataAccess.Context;
using TCAPP.Domain.RelationalData;

namespace TCAPP.API.Graphql.Contents.Strategies
{
    public class UpdateContentStringMetaValueStrategy : IAsyncUpdateStrategy<ContentStringMetaValue, UpdateStringMetaValueInput>
    {
        private readonly TCAPPContext _context;
        public UpdateContentStringMetaValueStrategy(TCAPPContext context)
        {
            _context = context;
        }
        public async Task<ContentStringMetaValue> UpdateAsync(UpdateStringMetaValueInput input)
        {
            var metaValue = await _context.ContentStringMetaValues.FindAsync(input.IdContent, input.IdMetaValueType);
            metaValue.Updated = DateTime.Now;
            metaValue.Enabled = input.Enabled ?? metaValue.Enabled;
            metaValue.Value = input.Value ?? metaValue.Value;
            await _context.SaveChangesAsync();
            return metaValue;
        }
    }
}
